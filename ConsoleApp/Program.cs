using System.Text;
using static System.String;

namespace ConsoleApp;

using TeamStatus = (string Name, int Mp, int W, int D, int L, int P);

public static class Tournament
{
    private const char InputSeparator = ';';
    private const string StatusWin = "win";
    private const string StatusLoss = "loss";
    private const string StatusDraw = "draw";

    public static void Tally(Stream inStream, Stream outStream)
    {
        var teams = ParseData(inStream);
        WriteToOutStream(
            [.. teams.Values.OrderByDescending(t => t.P).ThenBy(t => t.Name)],
            outStream
        );
    }

    private static void WriteToOutStream(TeamStatus[] teams, Stream outStream)
    {
        var sb = new StringBuilder();
        const string stringFormat = "{0,-30} | {1, 2} | {2,2} | {3,2} | {4,2} | {5,2}";
        sb.Append(Format(stringFormat, "Team", "MP", "W", "D", "L", "P"));
        foreach (var team in teams)
        {
            sb.Append('\n');
            sb.Append(Format(stringFormat, team.Name, team.Mp, team.W, team.D, team.L, team.P));
        }

        var writer = new StreamWriter(outStream);
        writer.Write(sb.ToString());
        writer.Flush();
    }

    private static Dictionary<string, TeamStatus> ParseData(Stream inStream)
    {
        var teams = new Dictionary<string, TeamStatus>();
        using var reader = new StreamReader(inStream);
        while (!reader.EndOfStream)
        {
            var split = ParseLine(reader);
            var (teamA, teamB, status) = (split[0], split[1], split[2]);
            var ta = new TeamStatus(teamA, 0, 0, 0, 0, 0);
            if (teams.TryGetValue(teamA, out var teamAScore))
            {
                ta = teamAScore;
            }

            var tb = new TeamStatus(teamB, 0, 0, 0, 0, 0);
            if (teams.TryGetValue(teamB, out var teamBScore))
            {
                tb = teamBScore;
            }

            UpdateTeamStatuses(status, ref ta, ref tb);
            teams[teamA] = ta;
            teams[teamB] = tb;
        }

        return teams;
    }

    private static void UpdateTeamStatuses(string status, ref TeamStatus ta, ref TeamStatus tb)
    {
        ta.Mp++;
        tb.Mp++;

        switch (status)
        {
            case StatusWin:
                ta.W++;
                ta.P += 3;
                tb.L++;
                break;
            case StatusLoss:
                ta.L++;
                tb.W++;
                tb.P += 3;
                break;
            case StatusDraw:
                ta.D++;
                ta.P++;
                tb.D++;
                tb.P++;
                break;
        }
    }

    private static string[] ParseLine(StreamReader reader)
    {
        var line = reader.ReadLine();
        return line == null ? [] : line.Split(InputSeparator);
    }
}

public class Program
{
    public static Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    public static void Main(string[] args)
    {
        const string data = """
                            Allegoric Alaskans;Blithering Badgers;win
                            Devastating Donkeys;Courageous Californians;draw
                            Devastating Donkeys;Allegoric Alaskans;win
                            Courageous Californians;Blithering Badgers;loss
                            Blithering Badgers;Devastating Donkeys;loss
                            Allegoric Alaskans;Courageous Californians;win
                            """;
        using var input = GenerateStreamFromString(data);
        Tournament.Tally(input, Stream.Null);
    }
}