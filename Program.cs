using System.Text;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < phoneNumber.Length; i++)
        {
            char c = phoneNumber[i];
            if (!char.IsDigit(c)) continue;
            if (sb.Length == 0 && c == '1') continue;
            sb.Append(c);
        }

        if (sb.Length != 10 || int.Parse(sb[0].ToString()) < 2 || int.Parse(sb[3].ToString()) < 2) throw new ArgumentException();

        return sb.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(PhoneNumber.Clean("+1 (613)-995-0253"));
        Console.WriteLine(PhoneNumber.Clean("613-995-0253"));
        Console.WriteLine(PhoneNumber.Clean("1 613 995 0253"));
        Console.WriteLine(PhoneNumber.Clean("613.995.0253"));
        Console.WriteLine(PhoneNumber.Clean("(023) 456-7890"));
    }
}