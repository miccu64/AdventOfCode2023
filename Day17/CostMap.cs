using AocHelpers;
using AocHelpers.Models;
using Day17.Models;

namespace Day17;

public class CostMap
{
    private readonly Grid<Cell> _grid;
    private readonly List<Direction> _allDirections = [Direction.Down, Direction.Right, Direction.Up, Direction.Left];
    private readonly Boundaries _boundaries;

    public CostMap(string fileName, Boundaries boundaries)
    {
        _boundaries = boundaries;
        _grid = new Grid<Cell>(fileName, c => new Cell(c));
    }

    public int DoDijkstra()
    {
        PointInfo<Cell> firstCellInfo = new(_grid[0, 0], 0, 0);
        firstCellInfo.Point.AddRangeTraversalInfos([new TraversalInfo(_boundaries)]);

        Queue<PointInfo<Cell>> queue = new();
        queue.Enqueue(firstCellInfo);

        while (queue.TryDequeue(out PointInfo<Cell>? currentCellInfo))
        {
            if (currentCellInfo.Point.IsVisited)
                continue;

            foreach (Direction direction in _allDirections)
            {
                PointInfo<Cell>? nextCellInfo = _grid.TryTraverse(currentCellInfo.X, currentCellInfo.Y, direction);
                if (nextCellInfo == null)
                    continue;

                List<TraversalInfo> possibleTraversals = currentCellInfo.Point.GetPossibleTraversalInfos(direction);
                if (possibleTraversals.Count == 0)
                    continue;

                nextCellInfo.Point.AddRangeTraversalInfos(
                    possibleTraversals.Select(t => t.Traverse(direction, nextCellInfo.Point.Cost))
                );

                if (!nextCellInfo.Point.IsVisited)
                    queue.Enqueue(nextCellInfo);
            }

            currentCellInfo.Point.MarkAsVisited();
        }

        return _grid[_grid.Width - 1, _grid.Height - 1].GetFinalPointResult(_boundaries);
    }
}