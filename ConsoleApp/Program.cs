using System;

public class Solution
{
}

namespace ConsoleApp
{
    public class Program
    {
        private static readonly Solution s = new();

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