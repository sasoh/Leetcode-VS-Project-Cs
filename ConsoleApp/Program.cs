using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    private const char Walkable = '.';

    private class CoordinateComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            return x != null && y != null && x[0] == y[0] && x[1] == y[1];
        }

        public int GetHashCode(int[] obj)
        {
            return obj[0] + obj[1] << 4;
        }
    }

    private static List<int[]> Neighbours(char[][] maze, int[] position)
    {
        var neighbours = new List<int[]>();
        var width = maze[0].Length;
        var height = maze.Length;
        var x = position[1];
        var y=  position[0];

        if (x - 1 >= 0 && maze[y][x - 1] == Walkable)
        {
            neighbours.Add(new[]
            {
                y,
                x - 1
            });
        }

        if (x + 1 < width && maze[y][x + 1] == Walkable)
        {
            neighbours.Add(new[]
            {
                y,
                x + 1
            });
        }
        
        if (y - 1 >= 0 && maze[y - 1][x] == Walkable)
        {
            neighbours.Add(new[]
            {
                y - 1,
                x
            });
        }
        
        if (y + 1 < height && maze[y + 1][x] == Walkable)
        {
            neighbours.Add(new[]
            {
                y + 1,
                x
            });
        }

        return neighbours;
    }

    private static bool IsExit(char[][] maze, int[] position)
    {
        var width = maze[0].Length;
        var height = maze.Length;
        var x = position[1];
        var y = position[0];
        return x == 0 || y == 0 || x == width - 1 || y == height - 1;
    }

    public int NearestExit(char[][] maze, int[] entrance)
    {
        var visited = new HashSet<int[]>(new CoordinateComparer()) {entrance};
        var next = new List<int[]> {new[] {entrance[0], entrance[1], 0}};
        var shortest = int.MaxValue;
        var foundShort = false;
        while (next.Count > 0)
        {
            var v = next.First();
            next.RemoveAt(0);
            
            var neighbours = Neighbours(maze, v);
            foreach (var n in neighbours)
            {
                if (!visited.Add(n)) continue;
                var distanceFromEntrance = v[2] + 1;
                next.Add(new[] {n[0], n[1], distanceFromEntrance});
                if (!IsExit(maze, n)) continue;
                if (distanceFromEntrance >= shortest) continue;
                shortest = distanceFromEntrance;
                foundShort = true;
            }
        }

        if (!foundShort) return -1;
        return shortest;
    }
}

namespace ConsoleApp
{
    public class Program
    {
        private static readonly Solution s = new();

        private static void T1()
        {
            var r = s.NearestExit(new[]
                {
                    new[] {'+', '+', '.', '+'},
                    new[] {'.', '.', '.', '+'},
                    new[] {'+', '+', '+', '.'}
                },
                new[] {1, 2}
            );
            Console.WriteLine($"Result = {r} expected = 1");
        }

        private static void T2()
        {
            var r = s.NearestExit(new[]
                {
                    new[] {'+', '+', '+'},
                    new[] {'.', '.', '.'},
                    new[] {'+', '+', '+'}
                },
                new[] {1, 0}
            );
            Console.WriteLine($"Result = {r} expected = 2");
        }

        private static void T3()
        {
            var r = s.NearestExit(new[]
                {
                    new[] {'.', '+'},
                },
                new[] {0, 0}
            );
            Console.WriteLine($"Result = {r} expected = -1");
        }
        
        private static void T4()
        {
            var r = s.NearestExit(new[]
                {
                    new[] {'.', '.', '.', '.', '.', '+', '.', '.', '.'},
                    new[] {'.', '+', '.', '.', '.', '.', '.', '.', '.'},
                    new[] {'.', '.', '+', '.', '+', '.', '+', '.', '+'},
                    new[] {'.', '.', '.', '.', '+', '.', '.', '.', '.'},
                    new[] {'.', '.', '.', '.', '+', '+', '.', '.', '.'},
                    new[] {'+', '.', '.', '.', '.', '.', '.', '.', '.'},
                    new[] {'.', '.', '.', '+', '.', '.', '.', '.', '.'},
                    new[] {'.', '.', '.', '+', '.', '.', '.', '.', '+'},
                    new[] {'+', '.', '.', '+', '.', '+', '+', '.', '.'}
                },
                new[] {8, 4}
            );
            Console.WriteLine($"Result = {r} expected = 5");
        }

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            // T1();
            // T2();
            // T3();
            T4();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}