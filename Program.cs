public static class ResistorColorTrio
{
    private static long ResistanceForKey(string key) => key switch
    {
        "black" => 0L,
        "brown" => 1L,
        "red" => 2L,
        "orange" => 3L,
        "yellow" => 4L,
        "green" => 5L,
        "blue" => 6L,
        "violet" => 7L,
        "grey" => 8L,
        "white" => 9L,
        _ => throw new NotImplementedException(),
    };

    public static string Label(string[] colors)
    {
        var sum = 0L;
        for (var i = 0; i < 2; i++)
        {
            var resistance = ResistanceForKey(colors[i]);
            sum += resistance * (long)Math.Pow(10, 1 - i);
        }
        var zeroes = ResistanceForKey(colors[2]);
        sum *= (long)Math.Pow(10, zeroes);
        var totalZeroes = CountZeroes(sum);
        var toTrim = (totalZeroes / 3) * 3;
        long trimmedSum = TrimmedSum(sum, toTrim);
        var suffix = toTrim switch
        {
            3 => "kilo",
            6 => "mega",
            9 => "giga",
            _ => ""
        };
        return $"{trimmedSum} {suffix}ohms";
    }

    private static long TrimmedSum(long sum, long toTrim)
    {
        for (var i = 0L; i < toTrim; ++i)
        {
            sum /= 10;
        }

        return sum;
    }

    private static long CountZeroes(long sum)
    {
        var totalZeroes = 0L;
        while (sum % 10 == 0 && sum > 0)
        {
            totalZeroes++;
            sum /= 10;
        }

        return totalZeroes;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine(ResistorColorTrio.Label(["orange", "orange", "black"]));
        //Console.WriteLine(ResistorColorTrio.Label(["red", "black", "red"]));
        //Console.WriteLine(ResistorColorTrio.Label(["black", "grey", "black"]));
        //Console.WriteLine(ResistorColorTrio.Label(["blue", "grey", "brown"]));
        //Console.WriteLine(ResistorColorTrio.Label(["yellow", "violet", "yellow"]));
        Console.WriteLine(ResistorColorTrio.Label(["white", "white", "white"]));
        Console.WriteLine(ResistorColorTrio.Label(["blue", "green", "yellow", "orange"]));
    }
}