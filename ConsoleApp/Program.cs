namespace ConsoleApp;

public static class TwoFer
{
    public static string Speak(string name = "") => string.IsNullOrEmpty(name) ? "One for you, one for me." : $"One for {name}, one for me.";
}


public class Program
{
    public static void Main(string[] args)
    {
    }
}