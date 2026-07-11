using Day16.Extensions;

namespace Day16.Models;

public class Point(char c)
{
    public PointType Type { get; } = c.ToPointType();

    private Direction EnergizedDirections { get; set; }

    public bool TryEnergize(Direction direction)
    {
        if (EnergizedDirections.HasFlag(direction))
            return false;

        EnergizedDirections |= direction;
        return true;
    }

    public bool IsEnergized() => EnergizedDirections > 0;
}