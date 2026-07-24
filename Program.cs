public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1) throw new ArgumentOutOfRangeException();
        var counter = 0;

        while (number > 1)
        {
            counter++;
            if (number % 2 == 0)
            {
                number /= 2;
            }
            else
            {
                number = 3 * number + 1;
            }
        }

        return counter;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}