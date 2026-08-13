using AocHelpers.Extensions;
using AocHelpers.Models;

namespace Day17.Models;

public class TraversalInfo(Boundaries boundaries)
{
    public int DistanceFromStart { get; private init; }
    public Direction LatestDirection { get; private init; }
    public int LatestDirectionRepeats { get; private init; }
    public bool IsVisited { get; private set; }

    public bool CanTraverse(Direction direction)
    {
        if (direction.IsOppositeDirection(LatestDirection))
            return false;
        if (LatestDirection == direction)
            return LatestDirectionRepeats < boundaries.MaxDirectionRepeats;

        bool allowStartingPoint = LatestDirectionRepeats == 0;
        return allowStartingPoint || LatestDirectionRepeats >= boundaries.MinDirectionRepeats;
    }

    public TraversalInfo Traverse(Direction direction, int cost)
    {
        if (!CanTraverse(direction))
            throw new InvalidOperationException("Traversal is not allowed");

        return new TraversalInfo(boundaries)
        {
            DistanceFromStart = DistanceFromStart + cost,
            LatestDirection = direction,
            LatestDirectionRepeats = LatestDirection == direction ? (LatestDirectionRepeats + 1) : 1
        };
    }

    public void MarkAsVisited()
    {
        IsVisited = true;
    }
}