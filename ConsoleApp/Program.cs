using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp
{
    public static class RunLengthEncoding
    {
        public static string Encode(string input)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < input.Length; ++i) {
                var current = input[i];
                if (i < input.Length - 1)
                {
                    var end = 0;
                    for (var j = i; j < input.Length; ++j)
                    {
                        var next = input[j];
                        if (current == next)
                        {
                            end = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    var d = end - i + 1;
                    if (d > 1)
                    {
                        sb.Append($"{d}{current}");
                        i = end;
                    }
                    else
                    {
                        sb.Append(current);
                    }
                }
                else {
                    sb.Append(current);
                }
            }
            return sb.ToString();
        }

        public static string Decode(string input)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < input.Length; ++i) {
                var current = input[i];
                if (char.IsDigit(current))
                {
                    var number = new List<int>();
                    number.Add(int.Parse(current.ToString()));
                    var letter = 0;
                    for (var j = i + 1; j < input.Length; ++j)
                    {
                        var next = input[j];
                        if (char.IsDigit(next))
                        {
                            number.Add(int.Parse(next.ToString()));
                        }
                        else
                        {
                            letter = j;
                            break;
                        }
                    }
                    int times = 0;
                    for (var j = 0; j < number.Count; ++j) {
                        var digit = number[number.Count - j - 1];
                        times += digit * Convert.ToInt32(Math.Pow(10, j));
                    }
                    for (var j = 0; j < times; ++j) {
                        sb.Append(input[letter]);
                    }
                    i = letter;
                }
                else
                {
                    sb.Append(current);
                }
            }
            return sb.ToString();
        }
    }

    public class Program
    {

        private static void T1()
        {
            //const string i = "AABCCCDEEEE";
            //var e = RunLengthEncoding.Encode(i);
            //var d = RunLengthEncoding.Encode(e);
            //Console.WriteLine($"{i} -> {e} -> {d}");
            //Console.WriteLine($"{RunLengthEncoding.Encode("XYZ")}");
            //Console.WriteLine($"{RunLengthEncoding.Encode("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB")}");
            Console.WriteLine($"{RunLengthEncoding.Decode("2AB3C4MP")}");
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