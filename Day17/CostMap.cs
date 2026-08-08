using AocHelpers;
using AocHelpers.Models;
using Day17.Models;

namespace Day17;

public class CostMap
{
    private readonly Grid<Cell> _grid;
    private readonly List<Direction> _allDirections = [Direction.Down, Direction.Right, Direction.Up, Direction.Left];

    public CostMap(string fileName)
    {
        _grid = new Grid<Cell>(fileName, c => new Cell(c));
    }

    public int DoDijkstra()
    {
        ExtendedPointInfo<Cell>? currentCellInfo = new(_grid[0, 0], 0, 0, Direction.Right);
        currentCellInfo.Point.TraversalInfos.Add(new TraversalInfo());

        while (currentCellInfo != null)
        {
            foreach (Direction direction in _allDirections)
            {
                ExtendedPointInfo<Cell>? nextCellInfo =
                    _grid.TryTraverse(currentCellInfo.X, currentCellInfo.Y, direction);
                if (nextCellInfo == null)
                    continue;

                List<TraversalInfo> possibleTraversals = currentCellInfo.Point.TraversalInfos
                    .Where(info => info.CanTraverse(direction))
                    .ToList();
                if (possibleTraversals.Count == 0)
                    continue;

                nextCellInfo.Point.TraversalInfos.AddRange(
                    possibleTraversals.Select(t => t.Traverse(direction, nextCellInfo.Point.Cost))
                );
            }

            currentCellInfo.Point.IsVisited = true;

            PointInfo<Cell>? lowestCellInfo = _grid.AllPoints.Where(cell =>
                    !cell.Point.IsVisited
                    && cell.Point.TraversalInfos.Any()
                )
                .OrderBy(cell => cell.Point.TraversalInfos.Min(info => info.DistanceFromStart))
                .FirstOrDefault();

            currentCellInfo = lowestCellInfo == null
                ? null
                : new ExtendedPointInfo<Cell>(
                    lowestCellInfo.Point, lowestCellInfo.X, lowestCellInfo.Y,
                    default // unneeded
                );
        }

        int endResult = _grid[_grid.Width - 1, _grid.Height - 1].TraversalInfos.Min(info => info.DistanceFromStart);
        return endResult;
    }
}