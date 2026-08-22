using AocHelpers;
using AocHelpers.Models;

namespace Day18.Models;

public class DigPlan
{
    private readonly List<DigInstruction> _digInstructions;

    public DigPlan(string fileName, List<DigInstruction> digInstructions)
    {
        _digInstructions = File.ReadAllLines(fileName)
            .Select(x => new DigInstruction(x))
            .ToList();
    }

    public void Apply()
    {
        Grid<LagoonInterior> grid = BuildGrid();
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