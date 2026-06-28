using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Robot
    {
        private string _name = GenerateName();
        private static Random _random = new();
        private static HashSet<string> _generated = new();

        public string Name => _name;

        private static string GenerateName()
        {
            bool contains = false;
            string name = "";
            do
            {
                name = $"{(char)('A' + _random.Next(26))}{(char)('A' + _random.Next(26))}{_random.Next(10)}{_random.Next(10)}{_random.Next(10)}";
                contains = _generated.Contains(name);
            } while (contains);

            return name;
        }

        public void Reset() => _name = GenerateName();
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