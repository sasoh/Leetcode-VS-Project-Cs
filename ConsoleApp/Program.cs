using System;
using System.Text;
namespace ConsoleApp
{
    public static class DifferenceOfSquares
    {
        public static int CalculateSquareOfSum(int max)
        {
            int sum = max * (max + 1) / 2;
            return sum * sum;
        }

        public static int CalculateSumOfSquares(int max) => max * (max + 1) * (2 * max + 1) / 6;
        public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }

    public class Program
    {
        private static void T1()
        {
        }

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            T1();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}