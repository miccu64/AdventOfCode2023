using Day16.Models;

namespace Day16;

public class Layout
{
    public int XLength { get; }
    public int YLength { get; }
    private readonly Point[,] _layout;

    public Layout(string fileName)
    {
        string[] text = File.ReadAllLines(fileName);

        XLength = text[0].Length;
        YLength = text.Length;

        _layout = new Point[XLength, YLength];
        for (int y = 0; y < YLength; y++)
        {
            for (int x = 0; x < XLength; x++)
            {
                _layout[x, y] = new Point(text[x][y]);
            }
        }
    }

    public int Traverse(int startX, int startY)
    {
        Traverse(startX, startY, GetStartDirection(startX, startY));

        return _layout.Cast<Point>().Count(point => point.IsEnergized());
    }

    private Direction GetStartDirection(int x, int y)
    {
        const int xMin = -1;
        const int yMin = -1;
        int xMax = XLength;
        int yMax = YLength;

        if (y > yMin && y < yMax)
        {
            if (x == xMin)
                return Direction.Right;
            if (x == xMax)
                return Direction.Left;
        }

        if (x > xMin && x < xMax)
        {
            if (y == yMin)
                return Direction.Down;
            if (y == yMax)
                return Direction.Up;
        }

        throw new InvalidOperationException();
    }

    private void Traverse(int startX, int startY, Direction direction)
    {
        List<Task> pendingTraversions = [];

        (Point point, int x, int y)? nextPointInfo = TryGetNextPoint(startX, startY, direction);
        while (nextPointInfo is { } currentPoint)
        {
            if (!currentPoint.point.TryEnergize(direction))
                break;

            PointType nextPointType = currentPoint.point.Type;

            bool directionChangesNeeded = !(nextPointType == PointType.EmptySpace
                                            || (nextPointType == PointType.HorizontalSplitter &&
                                                direction is Direction.Left or Direction.Right)
                                            || (nextPointType == PointType.VerticalSplitter &&
                                                direction is Direction.Up or Direction.Down));

            if (directionChangesNeeded)
            {
                switch (nextPointType)
                {
                    case PointType.SlashMirror or PointType.BackslashMirror:
                        direction = Reflect(nextPointType, direction);
                        break;
                    case PointType.HorizontalSplitter:
                        pendingTraversions.Add(TraverseTask(currentPoint.x, currentPoint.y, Direction.Right));

                        direction = Direction.Left;
                        break;
                    case PointType.VerticalSplitter:
                        pendingTraversions.Add(TraverseTask(currentPoint.x, currentPoint.y, Direction.Down));

                        direction = Direction.Up;
                        break;
                }
            }

            nextPointInfo = TryGetNextPoint(currentPoint.x, currentPoint.y, direction);
        }

        Task.WaitAll(pendingTraversions);
    }

    private Task TraverseTask(int startX, int startY, Direction direction)
    {
        return Task.Run(() => Traverse(startX, startY, direction));
    }

    private static Direction Reflect(PointType pointType, Direction direction) => (pointType, direction) switch
    {
        (PointType.SlashMirror, Direction.Up) => Direction.Right,
        (PointType.SlashMirror, Direction.Down) => Direction.Left,
        (PointType.SlashMirror, Direction.Left) => Direction.Down,
        (PointType.SlashMirror, Direction.Right) => Direction.Up,

        (PointType.BackslashMirror, Direction.Up) => Direction.Left,
        (PointType.BackslashMirror, Direction.Down) => Direction.Right,
        (PointType.BackslashMirror, Direction.Left) => Direction.Up,
        (PointType.BackslashMirror, Direction.Right) => Direction.Down,

        _ => throw new InvalidOperationException()
    };

    private (Point point, int x, int y)? TryGetNextPoint(int x, int y, Direction direction)
    {
        (int x, int y) newCoordinates = direction switch
        {
            Direction.Up => (x, y - 1),
            Direction.Down => (x, y + 1),
            Direction.Left => (x - 1, y),
            Direction.Right => (x + 1, y),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
        try
        {
            Point point = _layout[newCoordinates.y, newCoordinates.x];
            return (point, newCoordinates.x, newCoordinates.y);
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }
}