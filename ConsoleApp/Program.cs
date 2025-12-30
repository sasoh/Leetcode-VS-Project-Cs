using System;
using System.Collections.Generic;

public class Solution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        return new List<int>();
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
                new [] { 1,2 },
                new [] { 2,3},
                new [] { 5 },
                new [] { 0 },
                new [] { 5 },
                new int [] { },
                new int [] { }
            };
            var result = s.EventualSafeNodes(graph);
            Console.WriteLine($"Result = {string.Join(", ", result)}");
            Console.WriteLine($"Expected = [2, 4, 5, 6]");
        }

        private static void T2()
        {
            var graph = new[] {
                new [] { 1,2,3,4 },
                new [] { 1,2 },
                new [] { 3,4 },
                new [] { 0,4 },
                new int [] { }
            };
            var result = s.EventualSafeNodes(graph);
            Console.WriteLine($"Result = {string.Join(", ", result)}");
            Console.WriteLine($"Expected = [4]");
        }

        private static void RunTests()
        {

            Console.WriteLine("Running tests");

            T1();
            T2();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}