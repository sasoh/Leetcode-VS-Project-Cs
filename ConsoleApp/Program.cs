using System.Text;

namespace ConsoleApp;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var p = phrase.Replace('-', ' ');
        char[] cleaned = Array.FindAll(p.ToArray(), c => char.IsLetter(c) || char.IsWhiteSpace(c));

        var sb = new StringBuilder();
        for (var i = 0; i < cleaned.Length; i++)
        {
            var c = cleaned[i];
            if (i != 0)
            {
                var prev = cleaned[i - 1];
                if (!char.IsWhiteSpace(prev) || char.IsWhiteSpace(c)) continue;
            }
            sb.Append(char.ToUpper(c));
        }
        return sb.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine(Acronym.Abbreviate($"The Road _Not_ Taken"));
        //Console.WriteLine(Acronym.Abbreviate($"Liquid-crystal display"));
        Console.WriteLine(Acronym.Abbreviate($"Something - I made up from thin air"));
    }
}