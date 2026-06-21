using System;
namespace ConsoleApp
{
    public static class Darts
    {
        public static int Score(double x, double y)
        {
            var d = Math.Sqrt(x * x + y * y);
            if (d <= 1) return 10;
            if (d <= 5) return 5;
            if (d <= 10) return 1;
            return 0;
        }
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