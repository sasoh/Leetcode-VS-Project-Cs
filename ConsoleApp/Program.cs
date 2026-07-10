using System.Globalization;
namespace ConsoleApp;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => TimeZoneInfo.ConvertTimeFromUtc(dtUtc, TimeZoneInfo.Local);

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var tzi =  location switch
        {
            Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
            Location.London => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
            _ => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris")
        };
        return TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription, CultureInfo.CurrentCulture), tzi);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        var diff = alertLevel switch
        {
            AlertLevel.Early => TimeSpan.FromDays(1),
            AlertLevel.Standard => TimeSpan.FromMinutes(105),
            _ => TimeSpan.FromMinutes(30)
        };
        return appointment.Subtract(diff);
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var tzi =  location switch
        {
            Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
            Location.London => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
            _ => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris")
        };
        var before = tzi.IsDaylightSavingTime(dt.Subtract(TimeSpan.FromDays(7)));
        var now = tzi.IsDaylightSavingTime(dt);
        return before != now;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var ci =  location switch
        {
            Location.NewYork => CultureInfo.CreateSpecificCulture("en-US"),
            Location.London => CultureInfo.CreateSpecificCulture("en-UK"),
            _ => CultureInfo.CreateSpecificCulture("fr-FR")
        };
        if (DateTime.TryParse(dtStr, ci, out var dt))
        {
            return dt;
        }
        return new DateTime(1, 1, 1);
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