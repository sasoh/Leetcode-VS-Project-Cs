using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public static class Identifier
    {
        public static string Clean(string identifier)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < identifier.Length; i++)
            {
                var c = identifier[i];
                if (char.IsWhiteSpace(c))
                {
                    sb.Append('_');
                }
                else if (char.IsControl(c))
                {
                    sb.Append("CTRL");
                }
                else if (c == '-')
                {
                    if (i < identifier.Length - 1)
                    {
                        var nextC = identifier[i + 1];
                        sb.Append(char.ToUpper(nextC));
                        i++;
                    }
                }
                else if (!char.IsLetter(c) || c >= 'α' && c <= 'ω')
                {
                    continue;
                }
                else {
                    sb.Append(c);
                }
            }
            return sb.ToString();
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