using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class Pangram
    {
        public static bool IsPangram(string input)
        {
            var freq = new HashSet<char>();
            foreach (char c in input)
            {
                if (!char.IsLetter(c)) continue;
                var lowercased = char.ToLower(c);
                freq.Add(lowercased);
            }

            return freq.Count == 26;
        }
    }


    public class Program
    {

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}