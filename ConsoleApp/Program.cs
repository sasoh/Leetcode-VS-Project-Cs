using System;
using System.Collections.Generic;

public static class Solution
{
    private static void DFS(int[][] isConnected, HashSet<int> visited, int root)
    {
        visited.Add(root);
        for (var i = 0; i < isConnected.Length; i++)
        {
            if (visited.Contains(i) || isConnected[root][i] == 0) continue;
            DFS(isConnected, visited, i);
        }
    }

    public static int FindCircleNum(int[][] isConnected)
    {
        var visited = new HashSet<int>();
        int groups = 0;
        for (var i = 0; i < isConnected.Length; i++)
        {
            if (visited.Contains(i)) continue;
            groups++;
            DFS(isConnected, visited, i);
        }

        return groups;
    }
}

namespace ConsoleApp
{
    public class Program
    {
        public static void T1()
        {
            var data = new[]
            {
                new[] { 1, 1, 0 },
                new[] { 1, 1, 0 },
                new[] { 0, 0, 1 },
            };
            Console.Write($"found {Solution.FindCircleNum(data)} provinces");
        }

        public static void T2()
        {
            var data = new[]
            {
                new[] {1,0,0,1},
                new[] {0,1,1,0},
                new[] {0,1,1,1},
                new[] {1,0,1,1}
            };
            Console.Write($"found {Solution.FindCircleNum(data)} provinces");
        }

        public static void Tests()
        {
            //T1();
            T2();
        }

        public static void Main(string[] args)
        {
            Tests();
        }
    }
}