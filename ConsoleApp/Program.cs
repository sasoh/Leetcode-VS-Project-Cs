using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    public static class Triangle
    {
        private static bool IsValidTriangle(double side1, double side2, double side3) { 
            return (side1 + side2 > side3) && (side2 + side3 > side1) && (side3 + side1 > side2);
        }

        public static bool IsScalene(double side1, double side2, double side3)
        {
            if (!IsValidTriangle(side1, side2, side3)) return false;
            return side1 != side2 && side2 != side3 && side3 != side1;
        }

        public static bool IsIsosceles(double side1, double side2, double side3)
        {
            if (!IsValidTriangle(side1, side2, side3)) return false;
            return side1 == side2 || side2 == side3 || side3 == side1;
        }

        public static bool IsEquilateral(double side1, double side2, double side3)
        {
            if (!IsValidTriangle(side1, side2, side3)) return false;
            return side1 == side2 && side2 == side3;
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