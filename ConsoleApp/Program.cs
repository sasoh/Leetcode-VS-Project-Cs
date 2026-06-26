using System;

namespace ConsoleApp
{
    public enum LogLevel
    {
        Unknown = 0,
        Trace = 1,
        Debug = 2,
        Info = 4,
        Warning = 5,
        Error = 6,
        Fatal = 42
    };

    static class LogLine
    {

        public static LogLevel ParseLogLevel(string logLine)
        {
            var level = logLine.Substring(1, 3);
            return level switch
            {
                "TRC" => LogLevel.Trace,
                "DBG" => LogLevel.Debug,
                "INF" => LogLevel.Info,
                "WRN" => LogLevel.Warning,
                "ERR" => LogLevel.Error,
                "FTL" => LogLevel.Fatal,
                _ => LogLevel.Unknown
            };
        }

        public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
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