using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private Dictionary<char, int> _baseWordFrequency = new();
    private string _baseWord;

    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
        _baseWordFrequency = FrequencyForWord(_baseWord);
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var r = new List<string>();
        foreach (var w in potentialMatches)
        {
            if (w.ToLower() == _baseWord.ToLower()) continue;
            if (FrequencyForWord(w).Except(_baseWordFrequency).Any()) continue;
            r.Add(w);
        }
        return r.ToArray();
    }

    private Dictionary<char, int> FrequencyForWord(string word)
    {
        var r = new Dictionary<char, int>();
        foreach (var c in word)
        {
            var cl = char.ToLower(c);
            if (!r.ContainsKey(cl)) r.Add(cl, 0);
            r[cl] += 1;
        }
        return r;
    }
}

namespace ConsoleApp
{
    public class Program
    {
        private static void T1()
        {
            var a = new Anagram("solemn");
            var app = new[] { "melons", "lemons" };
            var an = a.FindAnagrams(app);
            Console.WriteLine(string.Join(", ", an));
        }

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            T1();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}