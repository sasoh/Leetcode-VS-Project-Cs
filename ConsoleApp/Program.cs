namespace ConsoleApp;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var r = new Dictionary<char, int> { 
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0,
        };
        foreach (var c in sequence)
        {
            if (!r.TryGetValue(c, out int value)) throw new ArgumentException();
            r[c] = ++value;
        }
        return r;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}