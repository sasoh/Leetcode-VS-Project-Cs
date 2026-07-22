namespace ConsoleApp;

[Flags]
public enum Allergen
{
    Eggs = 1 << 0,
    Peanuts = 1 << 1,
    Shellfish = 1 << 2,
    Strawberries = 1 << 3,
    Tomatoes = 1 << 4,
    Chocolate = 1 << 5,
    Pollen = 1 << 6,
    Cats = 1 << 7
}

public class Allergies
{
    private Allergen _allergies;

    public Allergies(int mask) => _allergies = (Allergen)mask;

    public bool IsAllergicTo(Allergen allergen) => (_allergies & allergen) != 0;

    public Allergen[] List()
    {
        var l = new List<Allergen>();
        foreach (var a in Enum.GetValues<Allergen>()) {
            if (!IsAllergicTo(a)) continue;
            l.Add(a);
        }
        return [.. l];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}