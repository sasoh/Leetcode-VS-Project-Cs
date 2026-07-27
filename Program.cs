public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var r = new List<List<int>>();
        for (var i = 0; i < rows; i++)
        {
            var row = new List<int> { 1 };
            if (i > 0)
            {
                var rowAbove = r[i - 1];
                for (var j = 1; j < i; j++)
                {
                    row.Add(rowAbove[j - 1] + rowAbove[j]);
                }

                row.Add(1);
            }
            r.Add(row);
        }

        return r;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PascalsTriangle.Calculate(4);
    }
}