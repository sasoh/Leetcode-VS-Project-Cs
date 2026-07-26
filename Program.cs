public static class ScrabbleScore
{
    private static int ScoreForLetter(char letter) => letter switch
    {
        'D' or 'G' => 2,
        'B' or 'C' or 'M' or 'P' => 3,
        'F' or 'H' or 'V' or 'W' or 'Y' => 4,
        'K' => 5,
        'J' or 'X' => 8,
        'Q' or 'Z' => 10,
        //'A' or 'E' or 'I' or 'O' or 'U' or 'L' or 'N' or 'R' or 'S' or 'T' => 1,
        _ => 1
    };

    public static int Score(string input)
    {
        var sum = 0;
        foreach (char letter in input)
        {
            sum += ScoreForLetter(char.ToUpper(letter));
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