using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Matrix
    {
        private readonly List<List<int>> _matrix = new();

        public Matrix(string input)
        {
            var rows = input.Split('\n');
            for (var i = 0; i < rows.Length; ++i) {
                _matrix.Add(new List<int>());
                var r = rows[i];
                var elements = r.Split(' ');
                foreach (var e in elements)
                {
                    _matrix[i].Add(int.Parse(e));
                }
            }
        }

        public int[] Row(int row) => _matrix[row - 1].ToArray();

        public int[] Column(int col)
        {
            var c = new List<int>();
            for (var i = 0; i < _matrix.Count; ++i) {
                c.Add(_matrix[i][col - 1]);
            }
            return c.ToArray();
        }
    }

    public class Program
    {

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            var sut = new Matrix("1 2\n3 4");

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}