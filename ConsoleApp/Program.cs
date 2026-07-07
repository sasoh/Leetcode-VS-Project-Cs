namespace ConsoleApp;

public class Authenticator
{
    private static Identity _admin = new() { Email = "admin@ex.ism", FacialFeatures = new() { EyeColor = "green", PhiltrumWidth = 0.9m }, NameAndAddress = ["Chanakya", "Mumbai", "India"] };

    public Identity Admin { get => _admin; }

    private static IDictionary<string, Identity> _developers = new Dictionary<string, Identity> {
        { "Bertrand", new() { Email = "bert@ex.ism", FacialFeatures = new() { EyeColor = "blue", PhiltrumWidth = 0.8m }, NameAndAddress = ["Bertrand", "Paris", "France"] } },
        { "Anders", new() { Email = "anders@ex.ism", FacialFeatures = new() { EyeColor = "brown", PhiltrumWidth = 0.85m }, NameAndAddress = ["Anders", "Redmond", "USA"] } }
    };

    public IDictionary<string, Identity> Developers { get => _developers; }
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public required string EyeColor { get; set; }
    public required decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public required string Email { get; set; }
    public required FacialFeatures FacialFeatures { get; set; }
    public required IList<string> NameAndAddress { get; set; }
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