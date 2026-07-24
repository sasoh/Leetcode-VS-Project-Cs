using System.Reflection.Metadata.Ecma335;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    private static int FactorSum(int number)
    {
        var sum = 0;
        for (int i = 1, limit = number / 2; i <= limit; i++)
        {
            if (number % i != 0) continue;
            sum += i;
        }

        return sum;
    }

    public static Classification Classify(int number) => number < 1
            ? throw new ArgumentOutOfRangeException()
            : (number - FactorSum(number)) switch
            {
                > 0 => Classification.Deficient,
                0 => Classification.Perfect,
                _ => Classification.Abundant
            };
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(PerfectNumbers.Classify(12));
    }
}