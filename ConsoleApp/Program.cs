using System;
using System.Globalization;

namespace ConsoleApp
{
    class WeighingMachine
    {
        private int _precision;
        public int Precision { get => _precision; }

        private double _weight;
        public double Weight
        {
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _weight = value;
            }

            get => _weight;
        }

        public double TareAdjustment { get; set; } = 5;

        public string DisplayWeight => string.Format(new NumberFormatInfo() { NumberDecimalDigits = _precision }, "{0:F} kg", new decimal(_weight - TareAdjustment));

        public WeighingMachine(int precision) => _precision = precision;
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