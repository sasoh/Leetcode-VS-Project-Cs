namespace ConsoleApp;

public class HighScores(List<int> scores)
{
    private readonly List<int> _scores = scores;

    public List<int> Scores() => _scores;

    public int Latest() => _scores[^1];

    public int PersonalBest()
    {
        var best = int.MinValue;
        foreach (var score in _scores)
        {
            if (score > best) {
                best = score;
            }
        }
        return best;
    }

    public List<int> PersonalTopThree()
    {
        var s = _scores.ToArray();
        s.Sort();
        int min = Math.Min(_scores.Count, 3);
        var list = new List<int>();
        for (var i = 0; i < min; ++i) {
            list.Add(s[^(i + 1)]);
        }
        return list;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}