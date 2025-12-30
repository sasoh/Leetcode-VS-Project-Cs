using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var keys = new HashSet<int> { 0 };
        var possible = new HashSet<int>(keys);
        var visited = new HashSet<int>();

        while (possible.Count > 0)
        {
            var first = possible.First();
            possible.Remove(first);
            visited.Add(first);

            var newKeys = rooms[first];
            foreach (var key in newKeys)
            {
                keys.Add(key);
                if (visited.Contains(key)) continue;
                possible.Add(key);
            }
        }

        return keys.Count == rooms.Count;
    }
}

namespace ConsoleApp
{
    public class Program
    {
        private static readonly Solution s = new();

        private static void T1()
        {
            var graph = new[] {
                new [] { 1 },
                new [] { 2 },
                new [] { 3 },
                new int [] { },
            };
            var result = s.CanVisitAllRooms(graph);
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Expected = true");
        }

        private static void T2()
        {
            var graph = new[] {
                new [] { 1, 3 },
                new [] { 3, 0, 1 },
                new [] { 2 },
                new [] { 0 },
            };
            var result = s.CanVisitAllRooms(graph);
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Expected = false");
        }

        private static void T3()
        {
            var graph = new[] {
                new [] { 1 },
                new [] { 1 }
            };
            var result = s.CanVisitAllRooms(graph);
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Expected = true");
        }

        private static void RunTests()
        {

            Console.WriteLine("Running tests");

            //T1();
            //T2();
            T3();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}