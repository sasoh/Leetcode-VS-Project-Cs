using System.Text;

namespace ConsoleApp;

// Generate a new string by changing each character in word to its next character in the English alphabet,
// and append it to the original word.
// For example, performing the operation on "c" generates "cd" and performing the operation on "zb" generates "zbac".
// Return the value of the kth character in word, after enough operations have been done for word to have at least k characters.

public class Solution
{
    public char KthCharacter(int k)
    {
        var word = new List<char> {'a'};
        while (word.Count < k)
        {
            word.AddRange(word.Select(t => (char) (t + 1)).ToList());
        }

        return word[k - 1];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var s = new Solution();
        Console.WriteLine(s.KthCharacter(5));
        // Console.WriteLine(s.KthCharacter(10));
    }
}