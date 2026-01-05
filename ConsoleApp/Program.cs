using System;
using System.Collections.Generic;

public class Solution
{
    private static readonly char Walkable = '.'; 
    
    private List<int[]> Neighbours(char[][] maze, int[] position)
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
                x - 1,
                y
            });
        }

        if (x + 1 < width && maze[y][x + 1] == Walkable)
        {
            neighbours.Add(new[]
            {
                x + 1,
                y
            });
        }
        
        if (y - 1 >= 0 && maze[y - 1][x] == Walkable)
        {
            neighbours.Add(new[]
            {
                x,
                y - 1
            });
        }
        
        if (y + 1 < height && maze[y + 1][x] == Walkable)
        {
            neighbours.Add(new[]
            {
                x,
                y + 1
            });
        }

        return neighbours;
    }

    public int NearestExit(char[][] maze, int[] entrance)
    {
        var distance = -1;
        return distance;
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

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            T1();
            // T2();
            // T1();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}