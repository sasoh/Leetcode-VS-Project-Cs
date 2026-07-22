using System.Text;

namespace ConsoleApp;

using Tag = (int from, int to, string key);

public class Solution
{
    public string Evaluate(string s, IList<IList<string>> knowledge)
    {
        var tags = ExtractTags(s);
        var knowledgeDictionary = knowledge.ToDictionary(l => l[0], l => l[1]);
        var sb = new StringBuilder(s);
        for (var i = 0; i < tags.Count; i++)
        {
            var t = tags[^(i + 1)];

            sb.Remove(t.from, t.to - t.from + 1);
            if (knowledgeDictionary.TryGetValue(t.key, out var value))
            {
                sb.Insert(t.from, value);   
            }
            else
            {
                sb.Insert(t.from, '?');
            }
        }

        return sb.ToString();
    }

    private static List<Tag> ExtractTags(string s)
    {
        var openBracketIndex = s.IndexOf('(');
        var values = new List<Tag>();
        while (openBracketIndex != -1)
        {
            var closeBracketIndex = s.IndexOf(')', openBracketIndex);
            if (closeBracketIndex == -1) continue;
            values.Add(new Tag(
                openBracketIndex,
                closeBracketIndex,
                s[(openBracketIndex + 1)..(closeBracketIndex)]
            ));
            openBracketIndex = s.IndexOf('(', closeBracketIndex);
        }

        return values;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var s = new Solution();
        s.Evaluate("(name)is(age)yearsold", [["name","bob"],["age","two"]]);
    }
}