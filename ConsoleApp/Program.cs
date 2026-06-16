using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 0) return 0.0;
        if (speed > 0 && speed < 5) return 1.0;
        if (speed > 4 && speed < 9) return 0.9;
        if (speed == 9) return 0.8;
        return 0.77;
    }

    public static double ProductionRatePerHour(int speed)
    {
        return 221 * SuccessRate(speed) * speed;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)ProductionRatePerHour(speed) / 60;
    }
}


namespace ConsoleApp
{
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