using System;

namespace ConsoleApp
{
    public static class SimpleCalculator
    {
        public static string Calculate(int operand1, int operand2, string? operation)
        {
            if (operation == null) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(operation)) throw new ArgumentException();
            if (operation == "+")
            {
                return string.Format($"{operand1} + {operand2} = {operand1 + operand2}");
            }
            else if (operation == "*")
            {
                return string.Format($"{operand1} * {operand2} = {operand1 * operand2}");
            }
            else if (operation == "/")
            {
                if (operand2 == 0) return "Division by zero is not allowed.";
                return string.Format($"{operand1} / {operand2} = {operand1 / operand2}");
            }
            throw new ArgumentOutOfRangeException();
        }
    }

    public class Program
    {

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}