using System.Xml.Linq;

namespace ConsoleApp;

public class Solution
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {

        // write out grid as a single element array
        var list = new List<int>();
        foreach (var row in grid) {
            list.AddRange(row);
        }

        // shift list by k elements
        for (var i = 0; i < k; ++i) {
            // take last
            var last = list[^1];
            list.RemoveAt(list.Count - 1);
            list.Insert(0, last);
            // push in front
        }


        // rebuild the matrix from shifted list
        var r = new List<IList<int>>();
        var rows = grid.Length;
        var cols = grid[0].Length;
        for (var i = 0; i < rows; ++i) {
            r.Add(list.GetRange(i * cols, cols));
        }
        return r;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var s = new Solution();
        //var p = s.ShiftGrid([[3, 8, 1, 9], [19, 7, 2, 5], [4, 6, 11, 10], [12, 0, 21, 13]], 3);
        //var p = s.ShiftGrid([[1, 2, 3], [4, 5, 6], [7, 8, 9]], 2);
        var p = s.ShiftGrid([[3, 8, 1, 9], [19, 7, 2, 5], [4, 6, 11, 10], [12, 0, 21, 13]], 4);
        Console.WriteLine(p);
    }
}