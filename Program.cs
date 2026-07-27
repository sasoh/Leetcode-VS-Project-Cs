public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength < 1 || numbers.Length < sliceLength) throw new ArgumentException();
        ArgumentException.ThrowIfNullOrEmpty(numbers);

        var slices = new List<string>();
        for (int i = 0, limit = numbers.Length - sliceLength; i <= limit; i++) {
            slices.Add(numbers[i..(i + sliceLength)]);
        }

        return [.. slices];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(string.Join(", ", Series.Slices("123456", 3)));
    }
}