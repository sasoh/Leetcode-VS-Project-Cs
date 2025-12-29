using System;
using System.Collections.Generic;
using System.Linq;

public static class Solution
{
    public static int FindCircleNum(int[][] isConnected)
    {
        var possibleGroupStarters = new HashSet<int>();
        for (var i = 0; i < isConnected.Length; i++)
        {
            possibleGroupStarters.Add(i);
        }
        var visited = new HashSet<int>();

        int groups = 0;
        while (possibleGroupStarters.Count > 0)
        {
            var groupStart = possibleGroupStarters.First();
            possibleGroupStarters.Remove(groupStart);
            visited.Add(groupStart);
            groups++;

            var connections = new HashSet<int>();
            for (var i = groupStart; i < isConnected.Length; i++)
            {
                if (isConnected[groupStart][i] == 1)
                {
                    connections.Add(i);
                }
            }

            while (connections.Count > 0)
            {
                var connection = connections.First();
                connections.Remove(connection);
                possibleGroupStarters.Remove(connection);
                visited.Add(connection);

                for (var i = 0; i < isConnected.Length; i++)
                {
                    if (isConnected[connection][i] == 1 && !visited.Contains(i))
                    {
                        connections.Add(i);
                    }
                }
            }
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