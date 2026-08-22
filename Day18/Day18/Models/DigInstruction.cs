using AocHelpers.Models;

namespace Day18.Models;

public class DigInstruction
{
    public Direction Direction { get; }
    public int DigCount { get; }
    public string HexColor { get; }

    public DigInstruction(string line)
    {
        List<string> parts = line.Split(' ').ToList();

        Direction = ParseDirection(parts[0]);
        DigCount = int.Parse(parts[1]);
        HexColor = parts[2];
    }

    private static Direction ParseDirection(string letter)
    {
        return letter switch
        {
            "L" => Direction.Left,
            "R" => Direction.Right,
            "U" => Direction.Up,
            "D" => Direction.Down,
            _ => throw new ArgumentOutOfRangeException(nameof(letter), letter, null)
        };
    }
}