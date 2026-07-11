namespace Day16.Models;

public class Layout
{
    private readonly Point[,] _layout;

    public Layout(string fileName)
    {
        string[] text = File.ReadAllLines(fileName);

        int xLength = text[0].Length;
        int yLength = text.Length;
        _layout = new Point[xLength, yLength];

        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < xLength; x++)
            {
                _layout[x, y] = new Point(text[x][y]);
            }
        }
    }

    public void Traverse()
    {
        Traverse(-1, 0, Direction.Right);
    }

    private void Traverse(int startX, int startY, Direction direction)
    {
        List<Task> pendingTraversions = [];

        (Point point, int x, int y)? nextPointInfo = TryGetNextPoint(startX, startY, direction);
        while (nextPointInfo != null)
        {
            nextPointInfo.Value.point.Energize();

            PointType nextPointType = nextPointInfo.Value.point.Type;

            bool noChanges = nextPointType == PointType.EmptySpace
                             || (nextPointType == PointType.HorizontalSplitter &&
                                 direction is Direction.Left or Direction.Right)
                             || (nextPointType == PointType.VerticalSplitter &&
                                 direction is Direction.Up or Direction.Down);

            if (noChanges)
            {
                nextPointInfo = TryGetNextPoint(startX, startY, direction);
            }
            else if (nextPointType == PointType.LeftToRightMirror)
            {
                direction = direction switch
                {
                    Direction.Up => Direction.Left,
                    Direction.Down => Direction.Right,
                    Direction.Left => Direction.Up,
                    Direction.Right => Direction.Down,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
            }
            else if (nextPointType == PointType.RightToLeftMirror)
            {
                direction = direction switch
                {
                    Direction.Up => Direction.Right,
                    Direction.Down => Direction.Left,
                    Direction.Left => Direction.Down,
                    Direction.Right => Direction.Up,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
            }
            else if (nextPointType == PointType.HorizontalSplitter)
            {
                pendingTraversions.Add(TraverseTask(nextPointInfo.Value.x, nextPointInfo.Value.y, Direction.Up));
                pendingTraversions.Add(TraverseTask(nextPointInfo.Value.x, nextPointInfo.Value.y, Direction.Down));
            }
            else if (nextPointType == PointType.VerticalSplitter)
            {
                pendingTraversions.Add(TraverseTask(nextPointInfo.Value.x, nextPointInfo.Value.y, Direction.Left));
                pendingTraversions.Add(TraverseTask(nextPointInfo.Value.x, nextPointInfo.Value.y, Direction.Right));
            }
        }

        Task.WaitAll(pendingTraversions);
    }

    private Task TraverseTask(int startX, int startY, Direction direction)
    {
        return Task.Run(() => Traverse(startX, startY, direction));
    }

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
            Point point = _layout[newCoordinates.x, newCoordinates.y];
            return (point, newCoordinates.x, newCoordinates.y);
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }
}