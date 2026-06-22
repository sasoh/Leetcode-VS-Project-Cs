using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    public static class AccumulateExtensions
    {
        public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
        {
            var i = collection.GetEnumerator();
            while (i.MoveNext())
            {
               yield return func(i.Current);
            }
        }
    }

    public class Program
    {
        private static void T1()
        {

            var p = new List<int> { 1, 2, 3, 4 };
            Console.WriteLine($"{string.Join(", ", p.Accumulate(i => i * i))}");
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