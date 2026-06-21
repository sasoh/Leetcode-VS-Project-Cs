using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    static class Appointment
    {
        public static DateTime Schedule(string appointmentDateDescription)
        {
            if (DateTime.TryParse(appointmentDateDescription, out var parsed)) {
                return parsed;
            }
            return DateTime.Now;
        }

        public static bool HasPassed(DateTime appointmentDate) => (DateTime.Now - appointmentDate).TotalSeconds > 0;

        public static bool IsAfternoonAppointment(DateTime appointmentDate) => appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;

        public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate}.";

        public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15);
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