using AocHelpers.Models;

namespace Day17.Models;

public class MultipleLatestDirectionsQueuesWrapper
{
    private List<LatestDirectionsQueue> _directionQueues = [];

    public void ConcatOtherMultipleDirections(
        MultipleLatestDirectionsQueuesWrapper multiQueueToCopy,
        Direction direction)
    {
        List<LatestDirectionsQueue> queuesToAdd = multiQueueToCopy._directionQueues
            .Where(q => q.CanTraverse(direction))
            .Select(q =>
            {
                LatestDirectionsQueue clone = (LatestDirectionsQueue)q.Clone();
                clone.EnqueueWithoutOverflow(direction);
                return clone;
            })
            .Distinct()
            .ToList();

        if (queuesToAdd.Count == 0)
            throw new InvalidOperationException("No directions to add available");

        _directionQueues = _directionQueues.Union(queuesToAdd).ToList();
    }

    public void ReplaceMultipleDirections(
        MultipleLatestDirectionsQueuesWrapper multiQueueToCopy,
        Direction direction)
    {
        _directionQueues = multiQueueToCopy._directionQueues
            .Where(q => q.CanTraverse(direction))
            .Select(q =>
            {
                LatestDirectionsQueue clone = (LatestDirectionsQueue)q.Clone();
                clone.EnqueueWithoutOverflow(direction);
                return clone;
            })
            .Distinct()
            .ToList();

        if (_directionQueues.Count == 0)
            throw new InvalidOperationException("No more directions available");
    }

    public void InitFirst(Direction direction)
    {
        LatestDirectionsQueue q = new();
        q.EnqueueWithoutOverflow(direction);
        _directionQueues.Add(q);
    }

    public bool CanTraverse(Direction direction)
    {
        if (_directionQueues.Count == 0)
            throw new InvalidOperationException("No more directions available");

        return _directionQueues.Any(q => q.CanTraverse(direction));
    }
}