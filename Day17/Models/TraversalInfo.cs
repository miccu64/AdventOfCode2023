using AocHelpers.Models;

namespace Day17.Models;

public class TraversalInfo(int distance)
{
    public int Distance { get; } = distance;
    private Direction LatestDirection { get; init; }
    private int LatestDirectionRepeats { get; init; }

    public bool CanTraverse(Direction direction)
    {
        if (LatestDirection != direction)
            return true;

        return LatestDirectionRepeats < 3;
    }

    public TraversalInfo Traverse(Direction direction, int cost)
    {
        int repeats;
        if (LatestDirection != direction)
        {
            repeats = 1;
        }
        else
        {
            if (LatestDirectionRepeats >= 3)
                throw new InvalidOperationException("Tried to traverse 4th time in the same direction");

            repeats = LatestDirectionRepeats + 1;
        }

        return new TraversalInfo(Distance + cost)
        {
            LatestDirection = direction,
            LatestDirectionRepeats = repeats
        };
    }
}