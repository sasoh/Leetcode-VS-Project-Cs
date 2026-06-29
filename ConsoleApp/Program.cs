using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp
{
    public static class Isogram
    {
        public static bool IsIsogram(string word)
        {
            var freq = new Dictionary<char, int>();
            foreach (char ch in word)
            {
                var lower = char.ToLower(ch);
                if (!char.IsLetter(lower)) continue;
                if (!freq.ContainsKey(lower)) freq.Add(lower, 0);
                freq[lower]++;
            }

            foreach (int f in freq.Values) {
                if (f > 1) return false;
            }

            return true;
        }
    }


    public class Program
    {

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            Isogram.IsIsogram("isogram");

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}