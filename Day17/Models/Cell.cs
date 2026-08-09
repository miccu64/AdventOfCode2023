using AocHelpers.Models;

namespace Day17.Models;

public class Cell(char c)
{
    public int Cost { get; } = int.Parse(c.ToString());
    public bool UnvisitedInfoExists => _traversalInfos.Any(i => !i.IsVisited);
    private List<TraversalInfo> _traversalInfos = [];

    public void AddRangeTraversalInfos(params TraversalInfo[] traversalInfos)
    {
        _traversalInfos.AddRange(traversalInfos);

        _traversalInfos = _traversalInfos.GroupBy(i => new { i.LatestDirection, i.LatestDirectionRepeats })
            .Select(g => g
                .OrderBy(i => i.DistanceFromStart)
                .ThenByDescending(i => i.IsVisited)
                .First()
            )
            .ToList();
    }

    public List<TraversalInfo> GetPossibleTraversalInfos(Direction direction)
    {
        return _traversalInfos.Where(i => i.CanTraverse(direction)).ToList();
    }

    public int GetMinTraversalDistance()
    {
        return _traversalInfos.Min(info => info.DistanceFromStart);
    }

    public void MarkAsVisited()
    {
        foreach (TraversalInfo info in _traversalInfos)
            info.MarkAsVisited();
    }
}