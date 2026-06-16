using System;
using System.Net.Security;

public static class LineUp
{
    public static string Format(string name, int number)
    {
        var rem = number % 10;
        var suffix = "th";
        if (rem == 1 && number % 100 != 11) {
            suffix = "st";
        }
        if (rem == 2 && number % 100 != 12) {
            suffix = "nd";
        }
        if (rem == 3 && number % 100 != 13)
        {
            suffix = "rd";
        }
        return $"{name}, you are the {number}{suffix} customer we serve today. Thank you!";
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