public static class SecretHandshake
{
    private enum Action
    {
        Wink = 1 << 0,
        DoubleBlink = 1 << 1,
        CloseYourEyes = 1 << 2,
        Jump = 1 << 3,
        Reverse = 1 << 4,
    }

    public static string[] Commands(int commandValue)
    {
        var commands = new List<string>();

        foreach (Action a in Enum.GetValues<Action>())
        {
            if ((commandValue & (int)a) == 0) continue;
            if (a == Action.Reverse)
            {
                commands.Reverse();
            }
            else
            {
                commands.Add(a switch
                {
                    Action.DoubleBlink => "double blink",
                    Action.CloseYourEyes => "close your eyes",
                    _ => a.ToString().ToLower()
                });
            }
        }

        return [.. commands];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SecretHandshake.Commands(26);
    }
}