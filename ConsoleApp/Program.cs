using System;
using System.Collections.Generic;
using System.Linq;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        return $"{(id != null ? $"[{id}] - ": "")}{name} - {(department != null ? department.ToUpper() : "OWNER")}";
    }
}

namespace ConsoleApp
{
    public class Program
    {
        private static void T1() { 
            
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