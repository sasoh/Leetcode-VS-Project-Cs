using System;
using System.Text;
namespace ConsoleApp
{
    public static class Gigasecond
    {
        public static DateTime Add(DateTime moment) => moment.AddSeconds(1000000000);
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