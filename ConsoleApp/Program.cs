using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    private static int DominoFaceForIndex(List<(int, int)> dominoes, int index)
    {
        return index > 0 ? dominoes[index - 1].Item1 : dominoes[-index - 1].Item2;
    }

    public static bool DoDominoFacesMatch(List<(int, int)> dominoes, int index1, int index2)
    {
        var value1 = DominoFaceForIndex(dominoes, -index1);
        var value2 = DominoFaceForIndex(dominoes, index2);
        return value1 == value2;
    }

    public static bool DoDominoFinalFacesMatch(List<(int, int)> dominoes, int first, int last)
    {
        var value1 = DominoFaceForIndex(dominoes, first);
        var value2 = DominoFaceForIndex(dominoes, -last);
        return value1 == value2;
    }

    public static bool IsSolved(List<int> solution, List<(int, int)> dominoes)
    {
        if (!DoDominoFinalFacesMatch(dominoes, solution.First(), solution.Last())) return false;

        for (int i = 0, limit = solution.Count; i < limit - 1; ++i)
        {
            var current = solution[i];
            var next = solution[i + 1];
            if (!DoDominoFacesMatch(dominoes, current, next)) return false;
        }

        return true;
    }

    public static bool ChainTest(List<int> solution, List<(int, int)> dominoes)
    {
        if (solution.Count == dominoes.Count)
        {
            return IsSolved(solution, dominoes);
        }

        for (int i = 0, limit = dominoes.Count; i < limit; ++i)
        {
            if (solution.Contains(i + 1) || solution.Contains(-(i + 1))) continue;
            solution.Add(i + 1);
            var result = ChainTest(solution, dominoes);
            if (result == true) return result;
            solution.RemoveAt(solution.Count - 1);

            solution.Add(-(i + 1));
            result = ChainTest(solution, dominoes);
            if (result == true) return result;
            solution.RemoveAt(solution.Count - 1);
        }

        return false;
    }

    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (dominoes.Count() == 0) return true;
        var list = dominoes.ToList();
        return ChainTest(new(), list);
    }
}

namespace ConsoleApp
{
    public class Program
    {
        private static void TestDominoFaceMatching()
        {
            var dom = new List<(int, int)>() {
                new (1, 2),
                new (2, 1),
            };
            Console.WriteLine(Dominoes.DoDominoFacesMatch(dom, 1, 2));
            Console.WriteLine(Dominoes.DoDominoFacesMatch(dom, -1, 2));
            Console.WriteLine(Dominoes.DoDominoFacesMatch(dom, 1, -2));
        }

        private static void TestIsSolved1()
        {
            var dom = new List<(int, int)>() {
                new (1, 2),
                new (2, 3),
                new (3, 4),
                new (4, 1)
            };
            Console.WriteLine(Dominoes.IsSolved(new List<int> { 1, 2, 3, 4 }, dom));
        }

        private static void TestIsSolved2()
        {
            var dom = new List<(int, int)>() {
                new (1, 2),
                new (2, 3),
                new (3, 1)
            };
            Console.WriteLine(Dominoes.IsSolved(new List<int> { 1, 2, 3 }, dom));
        }

        private static void TestIsSolved3()
        {
            var dom = new List<(int, int)>() {
                new (1, 2),
                new (2, 3),
                new (1, 3)
            };
            Console.WriteLine(Dominoes.IsSolved(new List<int> { 1, 2, -3 }, dom));
        }

        private static void T1()
        {
            Console.WriteLine(Dominoes.CanChain(new[] { (1, 2), (3, 1), (2, 3) }));
        }

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            //TestDominoFaceMatching();
            //TestIsSolved1();
            //TestIsSolved2();
            //TestIsSolved3();
            T1();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}