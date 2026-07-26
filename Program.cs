public static class ResistorColorDuo
{
    private static int ResistanceForKey(string key) => key switch
    {
        "black" => 0,
        "brown" => 1,
        "red" => 2,
        "orange" => 3,
        "yellow" => 4,
        "green" => 5,
        "blue" => 6,
        "violet" => 7,
        "grey" => 8,
        "white" => 9,
        _ => throw new NotImplementedException(),
    };

    public static int Value(string[] colors)
    {
        var sum = 0;
        for (var i = 0; i < colors.Length; i++)
        {
            var resistance = ResistanceForKey(colors[i]);
            sum += resistance * (int)Math.Pow(10, colors.Length - i - 1);
        }

        return sum;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
    }
}