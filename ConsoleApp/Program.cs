namespace ConsoleApp;

public static class MatchingBrackets
{
    private static bool IsOpening(char c) => c is '(' or '{' or '[';
    
    private static bool IsClosing(char c) => c is ')' or '}' or ']';
    
    private static bool CheckMatch(char o, char c) => (o == '(' && c == ')') || (o == '{' && c == '}') || (o == '[' && c == ']');

    public static bool IsPaired(string input)
    {
        var stack = new Stack<char>();
        foreach (var c in input)
        {
            if (IsOpening(c))
            {
                stack.Push(c);
            }
            else if (IsClosing(c))
            {
                if (stack.Count == 0) return false;
                var last = stack.Pop();
                if (!CheckMatch(last, c)) return false;
            }
        }

        return stack.Count == 0;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}