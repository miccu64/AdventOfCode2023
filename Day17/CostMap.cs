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
        currentCellInfo.Point.DistanceFromStart = 0;

        while (currentCellInfo != null)
        {
            foreach (Direction direction in _allDirections)
            {
                ExtendedPointInfo<Cell>? nextCellInfo =
                    _grid.TryTraverse(currentCellInfo.X, currentCellInfo.Y, direction);
                if (nextCellInfo == null || !currentCellInfo.Point.Queue.CanTraverse(nextCellInfo.UsedDirection))
                    continue;

                int newDistance = currentCellInfo.Point.DistanceFromStart + nextCellInfo.Point.Cost;
                if (nextCellInfo.Point.DistanceFromStart <= newDistance)
                    continue;

                nextCellInfo.Point.DistanceFromStart = newDistance;

                nextCellInfo.Point.Queue.EnqueueOtherDirections(
                    currentCellInfo.Point.Queue,
                    nextCellInfo.UsedDirection
                );
            }

            currentCellInfo.Point.IsVisited = true;

            currentCellInfo = _grid.AllPoints.Where(cell => !cell.Point.IsVisited)
                .OrderBy(cell => cell.Point.DistanceFromStart)
                .Select(cell =>
                    new ExtendedPointInfo<Cell>(cell.Point, cell.X, cell.Y, cell.Point.Queue.PeekLastDirection())
                )
                .FirstOrDefault();

            _grid.PrintGridToConsole(c => c.DistanceFromStart.ToString());
        }

        int endResult = _grid[_grid.Width - 1, _grid.Height - 1].DistanceFromStart;
        return endResult;
    }
}