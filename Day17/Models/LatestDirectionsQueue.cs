using AocHelpers.Extensions;
using AocHelpers.Models;

namespace Day17.Models;

public class LatestDirectionsQueue
{
    private const int ImportantHistoryCount = 3;
    private readonly Queue<Direction> _directions = new(ImportantHistoryCount);

    public bool CanTraverse(Direction direction)
    {
        Direction? latestDirection = _directions.LastOrDefault();
        if (latestDirection?.IsOppositeDirection(direction) == true)
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
        _directions.Clear();

        foreach (Direction d in queueToCopy._directions)
            EnqueueWithoutOverflow(d);

        EnqueueWithoutOverflow(direction);
    }

    public Direction PeekLastDirection()
    {
        return _directions.Last();
    }

    private void EnqueueWithoutOverflow(Direction direction)
    {
        if (_directions.Count == 3)
            _directions.Dequeue();

        _directions.Enqueue(direction);
    }
}