public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int numberOfDigits = CountDigits(number);
        int sum = 0;
        int temp = number;
        for (var i = 0; i < numberOfDigits; ++i)
        {
            var digit = temp % 10;
            temp /= 10;
            sum += (int)Math.Pow(digit, numberOfDigits);
        }

        return sum == number;
    }

    private static int CountDigits(int number)
    {
        var counter = 0;
        while (number > 0)
        {
            counter++;
            number /= 10;
        }

        return counter;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ArmstrongNumbers.IsArmstrongNumber(5);
        ArmstrongNumbers.IsArmstrongNumber(54);
        ArmstrongNumbers.IsArmstrongNumber(554);
        ArmstrongNumbers.IsArmstrongNumber(5454);
        ArmstrongNumbers.IsArmstrongNumber(51354);
        ArmstrongNumbers.IsArmstrongNumber(513554);
    }
}