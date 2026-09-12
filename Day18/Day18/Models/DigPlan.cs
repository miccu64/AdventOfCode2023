using AocHelpers;
using AocHelpers.Models;

namespace Day18.Models;

public class DigPlan
{
    private readonly List<DigInstruction> _digInstructions;

    private static readonly IReadOnlyList<Direction> AllDirections =
        [Direction.Down, Direction.Up, Direction.Left, Direction.Right];

    public DigPlan(string fileName)
    {
        _digInstructions = File.ReadAllLines(fileName)
            .Select(x => new DigInstruction(x))
            .ToList();
    }

    public int CountCubicMeters()
    {
        Grid<LagoonInterior> grid = BuildGrid();

        Queue<ExtendedPointInfo<LagoonInterior>> queue = new();
        queue.Enqueue(GetFirstInterior(grid));

        while (queue.TryDequeue(out ExtendedPointInfo<LagoonInterior>? point))
        {
            foreach (Direction direction in AllDirections)
            {
                ExtendedPointInfo<LagoonInterior>? nextPoint = grid.TryTraverse(point.X, point.Y, direction);
                if (nextPoint is { Point.IsDugOut: false })
                {
                    nextPoint.Point.MarkAsDugOut();
                    queue.Enqueue(nextPoint);
                }
            }

            point.Point.MarkAsDugOut();
        }

        grid.PrintGridToFile("result.txt", (i) => i.IsDugOut ? "#" : " ");

        return grid.AllPoints.Count(p => p.Point.IsDugOut);
    }

    private static ExtendedPointInfo<LagoonInterior> GetFirstInterior(Grid<LagoonInterior> grid)
    {
        int startX = grid.Width / 2;
        int y = 0;
        const Direction direction = Direction.Down;

        LagoonInterior firstPoint = grid[startX, y];
        if (firstPoint is not LagoonEdge)
        {
            while (grid.TryTraverse(startX, y, direction)?.Point is not LagoonEdge)
            {
                y++;
            }
        }

        while (grid.TryTraverse(startX, y, direction)?.Point is LagoonEdge)
        {
            y++;
        }

        return grid.TryTraverse(startX, y, direction)!;
    }

    private Grid<LagoonInterior> BuildGrid()
    {
        List<PointInfo<LagoonEdge>> edges = GetEdges();

        int xMin = edges.Min(x => x.X);
        int xMax = edges.Max(x => x.X);
        int yMin = edges.Min(x => x.Y);
        int yMax = edges.Max(x => x.Y);

        int height = yMax - yMin + 1;
        int width = xMax - xMin + 1;
        LagoonInterior[,] layout = new LagoonInterior[height, width];

        foreach (PointInfo<LagoonEdge> e in edges)
        {
            layout[e.Y - yMin, e.X - xMin] = e.Point;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (layout[y, x] is not LagoonEdge)
                    layout[y, x] = new LagoonInterior();
            }
        }

        return new Grid<LagoonInterior>(layout);
    }

    private List<PointInfo<LagoonEdge>> GetEdges()
    {
        int x = 0;
        int y = 0;

        return _digInstructions
            .SelectMany(instruction =>
            {
                int xDiff = 0;
                int yDiff = 0;
                switch (instruction.Direction)
                {
                    case Direction.Left:
                        xDiff = -1;
                        break;
                    case Direction.Right:
                        xDiff = 1;
                        break;
                    case Direction.Up:
                        yDiff = -1;
                        break;
                    case Direction.Down:
                        yDiff = 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(instruction.Direction),
                            instruction.Direction,
                            null
                        );
                }

                List<PointInfo<LagoonEdge>> points = [];
                for (int i = 1; i <= instruction.DigCount; i++)
                {
                    x += xDiff;
                    y += yDiff;

                    points.Add(new PointInfo<LagoonEdge>(new LagoonEdge(instruction.HexColor), x, y));
                }

                return points;
            })
            .ToList();
    }
}