using System;
using System.Collections.Generic;

internal class TreeNode
{
    public int TimeToInform;
    public int Index;
    public TreeNode Manager;
}

public class Solution
{
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {
        var nodes = new Dictionary<int, TreeNode>();
        for (var i = 0; i < n; i++)
        {
            var node = new TreeNode
            {
                TimeToInform = informTime[i],
                Index = i
            };
            nodes.Add(i, node);
        }
        
        for (var i = 0; i < n; i++)
        {
            var m = manager[i];
            if (m == manager[headID]) continue;
            nodes[i].Manager = nodes[m];
        }

        var largest = 0;
        for (var i = 0; i < n; i++)
        {
            var sum = 0;
            var m = nodes[i].Manager;
            while (m != null)
            {
                sum += nodes[m.Index].TimeToInform;
                m = m.Manager;
            }

            if (sum > largest)
            {
                largest = sum;
            }
        }

        return largest;
    }
}

namespace ConsoleApp
{
    public class Program
    {
        private static readonly Solution s = new();


        private static void T1()
        {
            var r = s.NumOfMinutes(
                1,
                0,
                new[] { -1 },
                new[] { 0 }
            );
            Console.WriteLine($"Result = {r}");
            Console.WriteLine($"Expected = 0");
        }
        
        private static void T2()
        {
            var r = s.NumOfMinutes(
                6,
                2,
                new[] { 2, 2, -1, 2, 2, 2 },
                new[] { 0, 0, 1, 0, 0, 0 }
            );
            Console.WriteLine($"Result = {r}");
            Console.WriteLine($"Expected = 1");
        }
        
        private static void T3()
        {
            var r = s.NumOfMinutes(
                7,
                6,
                new[] { 1, 2, 3, 4, 5, 6, -1 },
                new[] { 0, 6, 5, 4, 3, 2, 1 }
            );
            Console.WriteLine($"Result = {r}");
            Console.WriteLine($"Expected = 21");
        }
        
        private static void T4()
        {
            var r = s.NumOfMinutes(
                15,
                0,
                new[] { -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 },
                new[] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }
            );
            Console.WriteLine($"Result = {r}");
            Console.WriteLine($"Expected = 3");
        }

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            T1();
            T2();
            T3();
            T4();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}