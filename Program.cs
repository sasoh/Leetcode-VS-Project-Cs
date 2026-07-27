public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase) {
        if (inputBase < 2 || outputBase < 2 || inputDigits.Any(d => d < 0) || inputDigits.Any(d => d >= inputBase)) throw new ArgumentException(); 
        return [.. NumberInBase(outputBase, NumberIn10(inputBase, inputDigits))];
    }

    private static List<int> NumberInBase(int outputBase, int numberIn10)
    {
        var output = new List<int>();
        while (numberIn10 > 0)
        {
            output.Add(numberIn10 % outputBase);
            numberIn10 /= outputBase;
        }

        if (output.Count == 0)
        {
            output.Add(0);
        }
        else
        {
            output.Reverse();
        }

        return output;
    }

    private static int NumberIn10(int inputBase, int[] inputDigits)
    {
        var numberIn10 = 0;
        for (var i = 0; i < inputDigits.Length; i++)
        {
            numberIn10 += inputDigits[i] * (int)Math.Pow(inputBase, inputDigits.Length - i - 1);
        }

        return numberIn10;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine(string.Join(" ,", AllYourBase.Rebase(10, [1, 2, 3, 4], 2)));
        Console.WriteLine(string.Join(" ,", AllYourBase.Rebase(10, [4, 2], 2)));
    }
}