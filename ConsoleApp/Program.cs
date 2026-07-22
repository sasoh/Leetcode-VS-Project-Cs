using System.Text;

namespace ConsoleApp;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var rotation = shiftKey % 26;
        var sb = new StringBuilder();
        foreach (var c in text)
        {
            if (!char.IsLetter(c)) {
                sb.Append(c);
                continue;
            }

            var startChar = char.IsUpper(c)? 'A' : 'a';
            var offset = c - startChar;
            offset += rotation;
            offset %= 26;
            var newC = (char) (startChar + offset);
            sb.Append(newC);
        }
        return sb.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}