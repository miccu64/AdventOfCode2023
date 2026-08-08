using AocHelpers.Models;

namespace Day17.Models;

public class Cell(char c)
{
    public int Cost { get; } = int.Parse(c.ToString());
    public bool IsVisited { get; set; }
    private List<TraversalInfo> _traversalInfos = [];

    public void AddRangeTraversalInfos(params TraversalInfo[] traversalInfos)
    {
        _traversalInfos.AddRange(traversalInfos);

        _traversalInfos = _traversalInfos.GroupBy(i => new { i.LatestDirection, i.LatestDirectionRepeats })
            .Select(g => g.MinBy(i => i.DistanceFromStart)!)
            .ToList();
    }

    public List<TraversalInfo> GetPossibleTraversalInfos(Direction direction)
    {
        return _traversalInfos.Where(i => i.CanTraverse(direction)).ToList();
    }

    public int GetMinTraversalDistance()
    {
        return _traversalInfos.Any()
            ? _traversalInfos.Min(info => info.DistanceFromStart)
            : int.MaxValue;
    }
}