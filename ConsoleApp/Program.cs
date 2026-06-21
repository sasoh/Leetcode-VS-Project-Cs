using System;
using System.Text;

namespace ConsoleApp
{
    public static class ReverseString
    {
        public static string Reverse(string input)
        {
            var s = new StringBuilder();
            for (var i = input.Length - 1; i >= 0; --i) {
                s.Append(input[i]);
            }
            return s.ToString();
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