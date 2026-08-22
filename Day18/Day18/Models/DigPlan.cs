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
        List<PointInfo<LagoonEdge>> edges = GetEdges();
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