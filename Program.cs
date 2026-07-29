public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator(Direction Direction, int X, int Y)
{
    public Direction Direction { get; private set; } = Direction;

    public int X { get; private set; } = X;

    public int Y { get; private set; } = Y;

    public void Move(string instructions)
    {
        foreach (char instruction in instructions)
        {
            X += instruction switch
            {
                'A' when Direction is Direction.East => 1,
                'A' when Direction is Direction.West => -1,
                _ => 0
            };
            Y += instruction switch
            {
                'A' when Direction is Direction.North => 1,
                'A' when Direction is Direction.South => -1,
                _ => 0
            };
            Direction = instruction switch
            {
                'L' => (Direction)((int)(Direction - 1) < 0 ? (int)Direction.West : (int)(Direction - 1)),
                'R' => (Direction)((int)(Direction + 1) % Enum.GetValues<Direction>().Length),
                _ => Direction,
            };
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}