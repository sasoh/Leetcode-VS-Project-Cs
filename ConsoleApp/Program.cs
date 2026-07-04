using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public interface IRemoteControlCar {
        void Drive();
        int DistanceTravelled { get; }
    }

    public class ProductionRemoteControlCar: IRemoteControlCar, IComparable
    {
        public int DistanceTravelled { get; private set; }
        public int NumberOfVictories { get; set; }

        public void Drive() => DistanceTravelled += 10;

        public int CompareTo(object obj)
        {
            if (obj is ProductionRemoteControlCar c) {
                return NumberOfVictories - c.NumberOfVictories switch { 
                    < 0 => -1,
                    0 => 0,
                    > 0 => 1
                };
            }
            throw new NotImplementedException();
        }
    }

    public class ExperimentalRemoteControlCar: IRemoteControlCar
    {
        public int DistanceTravelled { get; private set; }

        public void Drive() => DistanceTravelled += 20;
    }

    public static class TestTrack
    {
        public static void Race(IRemoteControlCar car) => car.Drive();

        public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
            ProductionRemoteControlCar prc2) => prc1.CompareTo(prc2) switch
            {
                -1 => new List<ProductionRemoteControlCar> { prc1, prc2 },
                _ => new List<ProductionRemoteControlCar> { prc2, prc1 }
            };
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