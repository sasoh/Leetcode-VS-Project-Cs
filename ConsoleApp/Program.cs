using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp
{
    public static class Languages
    {
        public static List<string> NewList() => new();

        public static List<string> GetExistingLanguages() => new() { "C#", "Clojure", "Elm" };

        public static List<string> AddLanguage(List<string> languages, string language)
        {
            languages.Add(language);
            return languages;
        }

        public static int CountLanguages(List<string> languages) => languages.Count;

        public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

        public static List<string> ReverseList(List<string> languages)
        {
            languages.Reverse();
            return languages;
        }

        public static bool IsExciting(List<string> languages) => languages.Count > 0 && (languages[0] == "C#" || (languages.Count > 2 && languages.Count < 4 && languages[1] == "C#"));

        public static List<string> RemoveLanguage(List<string> languages, string language)
        {
            languages.Remove(language);
            return languages;
        }

        public static bool IsUnique(List<string> languages)
        {
            for (var i = 0; i < languages.Count; ++i) {
                for (var j = i + 1; j < languages.Count; ++j) { 
                    if (languages[i] == languages[j]) return false;
                }
            }
            return true;
        }
    }

    public class Program
    {

        private static void T1()
        {
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