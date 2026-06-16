using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var numbers = phoneNumber.Split('-');
        var isNewYork = numbers[0] == "212";
        var isFake = numbers[1] == "555";
        return (isNewYork, isFake, numbers[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}

namespace ConsoleApp
{
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