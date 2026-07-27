public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var allMultiples = new HashSet<int>();
        foreach (var multiple in multiples)
        {
            for (var i = 1; i < max; ++i)
            {
                if (i * multiple >= max) continue;
                allMultiples.Add(i * multiple);
            }
        }

        return allMultiples.Sum();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SumOfMultiples.Sum([2, 3], 10);
    }
}