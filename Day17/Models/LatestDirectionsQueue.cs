using AocHelpers.Extensions;
using AocHelpers.Models;

namespace Day17.Models;

public class LatestDirectionsQueue : ICloneable, IEquatable<LatestDirectionsQueue>
{
    private const int ImportantHistoryCount = 3;
    private List<Direction> _directions = new(ImportantHistoryCount);

    public bool CanTraverse(Direction direction)
    {
        Direction? latestDirection = _directions.LastOrDefault();
        if (direction.IsOppositeDirection(latestDirection))
            return false;

        bool incompleteQueue = _directions.Count < ImportantHistoryCount;
        if (incompleteQueue)
            return true;

        List<Direction> uniqueDirections = _directions.Distinct().ToList();
        if (uniqueDirections.Count > 1)
            return true;

        return uniqueDirections.Single() != direction;
    }

    public void EnqueueWithoutOverflow(Direction direction)
    {
        if (_directions.Count == 3)
            _directions.RemoveAt(0);

        _directions.Add(direction);
    }

    public object Clone()
    {
        return new LatestDirectionsQueue
        {
            _directions = _directions.ToList()
        };
    }

    public bool Equals(LatestDirectionsQueue? other)
    {
        return other != null && _directions.SequenceEqual(other._directions);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as LatestDirectionsQueue);
    }

    public override int GetHashCode()
    {
        HashCode hash = new();
        foreach (Direction d in _directions)
        {
            hash.Add(d.GetHashCode());
        }

        return hash.ToHashCode();
    }
}