using AocHelpers.Models;

namespace Day17.Models;

public class Cell(char c, Boundaries boundaries)
{
    public int Cost { get; } = int.Parse(c.ToString());
    private List<TraversalInfo> _orderedTraversalInfos = [];
    private const int MaxSingleCost = 9;
    private int MaxPossible { get; } = MaxSingleCost * boundaries.MaxDirectionRepeats;

    public void AddRangeTraversalInfos(params TraversalInfo[] traversalInfos)
    {
        // _orderedTraversalInfos = _orderedTraversalInfos
        //     .Concat(traversalInfos)
        //     .GroupBy(i => i.LatestDirection)
        //     .SelectMany(g =>
        //     {
        //         List<TraversalInfo> ordered = g
        //             .OrderBy(i => i.DistanceFromStart)
        //             .ThenBy(i => i.LatestDirectionRepeats)
        //             .ThenByDescending(i => i.IsVisited)
        //             .ToList();
        //
        //         if (ordered.Count == 1)
        //             return ordered;
        //
        //         List<TraversalInfo> relevantInfos =
        //         [
        //             ordered[0]
        //         ];
        //
        //         ordered.RemoveAt(0);
        //
        //         int maxDistance = ordered[0].DistanceFromStart + MaxPossible;
        //
        //         foreach (TraversalInfo info in ordered)
        //         {
        //             // if (info.DistanceFromStart > maxDistance)
        //             //     break;
        //
        //             if (info.LatestDirectionRepeats < relevantInfos.Last().LatestDirectionRepeats)
        //                 relevantInfos.Add(info);
        //         }
        //
        //         return relevantInfos;
        //     })
        //     .OrderBy(i => i.DistanceFromStart)
        //     .ToList();
        
        _orderedTraversalInfos = _orderedTraversalInfos
            .Concat(traversalInfos)
            .GroupBy(i => new { i.LatestDirection, i.LatestDirectionRepeats })
            .Select(g => g
                .OrderBy(i => i.DistanceFromStart)
                .ThenByDescending(i => i.IsVisited)
                .First()
            )
            .OrderBy(i => i.DistanceFromStart)
            .ToList();
    }

    public List<TraversalInfo> GetPossibleTraversalInfos(Direction direction)
    {
        return _orderedTraversalInfos.Where(i => i.CanTraverse(direction)).ToList();
    }

    public int? GetMinUnvisitedTraversalDistance()
    {
        return _orderedTraversalInfos.FirstOrDefault(i => !i.IsVisited)?.DistanceFromStart;
    }

    public int GetFinalPointResult()
    {
        return _orderedTraversalInfos
            .First(i => i.LatestDirectionRepeats >= boundaries.MinDirectionRepeats)
            .DistanceFromStart;
    }

    public void MarkAsVisited()
    {
        foreach (TraversalInfo info in _orderedTraversalInfos)
            info.MarkAsVisited();
    }
}