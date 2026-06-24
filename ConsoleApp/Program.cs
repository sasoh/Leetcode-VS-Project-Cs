using System;
using System.Text;
namespace ConsoleApp
{
    public class SpaceAge
    {
        private int _age;
        public SpaceAge(int seconds) => _age = seconds;
        public double OnEarth() => _age / 31557600.0;
        public double OnMercury() => OnEarth() / 0.2408467;
        public double OnVenus() => OnEarth() / 0.61519726;
        public double OnMars() => OnEarth() / 1.8808158;
        public double OnJupiter() => OnEarth() / 11.862615;
        public double OnSaturn() => OnEarth() / 29.447498;
        public double OnUranus() => OnEarth() / 84.016846;
        public double OnNeptune() => OnEarth() / 164.79132;
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