public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0) return [];
        var lines = new List<string>();
        for (var i = 0; i < subjects.Length - 1; i++)
        {
            lines.Add($"For want of a {subjects[i]} the {subjects[i + 1]} was lost.");
        }
        lines.Add($"And all for the want of a {subjects[0]}.");

        return [.. lines];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}