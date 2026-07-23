namespace ConsoleApp;

public class Clock : IEquatable<Clock>
{
    private readonly int _minutes = 0;
    private readonly int _hours = 0;

    public Clock(int hours, int minutes)
    {
        var totalMinutes = minutes + hours * 60;
        while (totalMinutes < 0)
        {
            totalMinutes = 24 * 60 + totalMinutes;
        }

        _hours = (totalMinutes / 60) % 24;
        _minutes = totalMinutes % 60;
    }

    public Clock Add(int minutesToAdd) => new(_hours, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new(_hours, _minutes - minutesToSubtract);

    public bool Equals(Clock? other)
    {
        if (other is null) return false;
        return _minutes == other._minutes && _hours == other._hours;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Clock) obj);
    }

    public override int GetHashCode() => HashCode.Combine(_minutes, _hours);

    public override string ToString() => $"{_hours:00}:{_minutes:00}";
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}