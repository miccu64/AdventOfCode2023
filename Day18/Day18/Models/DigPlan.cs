using AocHelpers;
using AocHelpers.Models;

namespace Day18.Models;

public class DigPlan
{
    private readonly List<DigInstruction> _digInstructions;

    public DigPlan(string fileName)
    {
        _digInstructions = File.ReadAllLines(fileName)
            .Select(x => new DigInstruction(x))
            .ToList();
    }

    public int CountCubicMeters()
    {
        Grid<LagoonInterior> grid = BuildGrid();

        for (int y = 0; y < grid.Height; y++)
        {
            bool isInside = false;
            int edgeCounter = 0;
            for (int x = 0; x < grid.Width; x++)
            {
                TryMarkAsDugOut(grid[x, y], ref isInside, ref edgeCounter);
            }
        }

        for (int x = 0; x < grid.Width; x++)
        {
            bool isInside = false;
            int edgeCounter = 0;
            for (int y = 0; y < grid.Height; y++)
            {
                TryMarkAsDugOut(grid[x, y], ref isInside, ref edgeCounter);
            }
        }

        grid.PrintGridToConsole((i) => i.IsDugOut ? "1" : "0");

        return grid.AllPoints.Count(p => p.Point.IsDugOut);
    }

    private static void TryMarkAsDugOut(LagoonInterior point, ref bool isInside, ref int edgeCounter)
    {
        if (point is LagoonEdge)
        {
            edgeCounter++;

            isInside = edgeCounter == 1 && !isInside;
        }
        else
        {
            if (isInside)
                point.MarkAsDugOut();

            edgeCounter = 0;
        }
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
            layout[e.Y, e.X] = e.Point;
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