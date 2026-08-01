using AocHelpers.Extensions;
using AocHelpers.Models;

namespace Day17.Models;

public class MultipleLatestDirectionsQueuesWrapper
{
    private List<LatestDirectionsQueue> _directionQueues = [];

    public void ConcatOtherMultipleDirections(
        MultipleLatestDirectionsQueuesWrapper multiQueueToCopy,
        Direction direction)
    {
        _directionQueues = _directionQueues.Union(
            multiQueueToCopy._directionQueues.Select(q =>
                {
                    LatestDirectionsQueue clone = (LatestDirectionsQueue)q.Clone();
                    clone.EnqueueWithoutOverflow(direction);
                    return clone;
                })
                .Distinct()
        ).ToList();
    }

    public void ReplaceMultipleDirections(
        MultipleLatestDirectionsQueuesWrapper multiQueueToCopy,
        Direction direction)
    {
        _directionQueues = multiQueueToCopy._directionQueues.Select(q =>
            {
                LatestDirectionsQueue clone = (LatestDirectionsQueue)q.Clone();
                clone.EnqueueWithoutOverflow(direction);
                return clone;
            })
            .Distinct()
            .ToList();
    }

    public bool CanTraverse(Direction direction)
    {
        return _directionQueues.Count == 0 || _directionQueues.Any(q => q.CanTraverse(direction));
    }
}

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

    public void EnqueueOtherDirections(LatestDirectionsQueue queueToCopy, Direction direction)
    {
        _directions = queueToCopy._directions.ToList();
        EnqueueWithoutOverflow(direction);
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
}