public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var kept = new List<T>();
        foreach (var e in collection)
        {
            if (!predicate(e)) continue;
            kept.Add(e);
        }

        foreach (var e in kept)
        {
            yield return e;
        }
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var kept = new List<T>();
        foreach (var e in collection)
        {
            if (predicate(e)) continue;
            kept.Add(e);
        }

        foreach (var e in kept)
        {
            yield return e;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}