namespace ConsoleApp;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.currency != rhs.currency) throw new ArgumentException();
        return lhs.amount == rhs.amount;
    }

    public static bool operator !=(CurrencyAmount lhs, CurrencyAmount rhs) => !(lhs == rhs);

    public static bool operator <(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.currency != rhs.currency) throw new ArgumentException();
        return lhs.amount < rhs.amount;
    }

    public static bool operator >(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.currency != rhs.currency) throw new ArgumentException();
        return lhs.amount > rhs.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.currency != rhs.currency) throw new ArgumentException();
        return new() { currency = lhs.currency, amount = lhs.amount + rhs.amount };
    }

    public static CurrencyAmount operator -(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.currency != rhs.currency) throw new ArgumentException();
        return new() { currency = lhs.currency, amount = lhs.amount - rhs.amount };
    }

    public static CurrencyAmount operator *(CurrencyAmount lhs, decimal rhs) => new() { currency = lhs.currency, amount = lhs.amount * rhs };

    public static CurrencyAmount operator /(CurrencyAmount lhs, decimal rhs) => new() { currency = lhs.currency, amount = lhs.amount / rhs };

    public static CurrencyAmount operator *(decimal lhs, CurrencyAmount rhs) => rhs * lhs;

    public static CurrencyAmount operator /(decimal lhs, CurrencyAmount rhs) => new() { currency = rhs.currency, amount = lhs / rhs.amount };

    public static explicit operator double(CurrencyAmount lhs) => (double)lhs.amount;

    //public static explicit operator decimal(CurrencyAmount lhs) => lhs.amount;

    public static implicit operator decimal(CurrencyAmount lhs) => lhs.amount;
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