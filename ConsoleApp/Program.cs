using System.Text;

namespace ConsoleApp;

public static class RnaTranscription
{
    private static readonly Dictionary<char, char> _map = new()
    {
        ['A'] = 'U',
        ['C'] = 'G',
        ['G'] = 'C',
        ['T'] = 'A',
    };

    public static string ToRna(string strand)
    {
        var sb = new StringBuilder();

        foreach (char c in strand)
        {
            sb.Append(_map[c]);
        }

        return sb.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}