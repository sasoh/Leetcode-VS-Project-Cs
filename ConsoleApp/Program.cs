using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class ProteinTranslation
    {
        private static bool IsStop(in string str) => str is "UAA" or "UAG" or "UGA";

        private static readonly Dictionary<HashSet<string>, string> codonsToProteins = new() {
            { new (){ "AUG" }, "Methionine" },
            { new (){ "UUU", "UUC" }, "Phenylalanine" },
            { new (){ "UUA", "UUG" }, "Leucine" },
            { new (){ "UCU", "UCC", "UCA", "UCG" }, "Serine" },
            { new (){ "UAU", "UAC" }, "Tyrosine" },
            { new (){ "UGU", "UGC" }, "Cysteine" },
            { new (){ "UGG" }, "Tryptophan" }
        };

        private static string CodonToAmino(in string str)
        {
            foreach (var p in codonsToProteins)
            {
                if (!p.Key.Contains(str)) continue;
                return p.Value;

            }
            return "";
        }

        public static string[] Proteins(string strand)
        {
            var r = new List<string>();

            for (var i = 0; i < strand.Length; i += 3)
            {
                var substring = strand.Substring(i, 3);
                if (IsStop(substring)) break;
                r.Add(CodonToAmino(substring));
            }

            return r.ToArray();
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