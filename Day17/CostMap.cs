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
        DirectionCounter directionCounter = new(Direction.Right);
        PointInfo<Cell>? currentCellInfo = new(_grid[0, 0], 0, 0, Direction.Right);

        while (currentCellInfo != null)
        {
            PointInfo<Cell>? optimalCellInfo = _allDirections
                .Select(direction => _grid.TryTraverse(currentCellInfo.X, currentCellInfo.Y, direction))
                .Where(info =>
                    info is { Point.IsVisited: false } && directionCounter.CanUseDirection(info.UsedDirection)
                )
                .OrderBy(info => info!.Point.Cost)
                .FirstOrDefault();

            if (optimalCellInfo != null)
            {
                optimalCellInfo.Point.DistanceFromStart =
                    optimalCellInfo.Point.Cost + currentCellInfo.Point.DistanceFromStart;
                directionCounter.Update(optimalCellInfo.UsedDirection);
            }

            currentCellInfo = optimalCellInfo;
        }

        int endResult = _grid[_grid.Width - 1, _grid.Height - 1].DistanceFromStart;
        return endResult;
    }

    class DirectionCounter
    {
        private Direction Direction { get; set; }
        private int Counter { get; set; }

        public DirectionCounter(Direction direction)
        {
            Direction = direction;
        }

        public bool CanUseDirection(Direction direction)
        {
            return Direction == direction && Counter < 3;
        }

        public void Update(Direction direction)
        {
            if (Direction == direction)
            {
                Counter++;
            }
            else
            {
                Direction = direction;
                Counter = 1;
            }
        }
    }
}