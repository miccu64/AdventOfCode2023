using Day16.Models;

namespace Day16;

public class Layout
{
    private readonly Grid<Point> _grid;

    public Layout(string fileName)
    {
        _grid = new Grid<Point>(fileName, c => new Point(c));
    }

    public int Traverse(int startX, int startY)
    {
        Traverse(startX, startY, GetStartDirection(startX, startY));

        return _grid.AllPoints.Count(point => point.IsEnergized());
    }

    private Direction GetStartDirection(int x, int y)
    {
        const int xMin = -1;
        const int yMin = -1;
        int xMax = _grid.Width;
        int yMax = _grid.Height;

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
        (Point point, int x, int y)? nextPointInfo = _grid.TryTraverse(startX, startY, direction);
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
                        Traverse(currentPoint.x, currentPoint.y, Direction.Right);

                        direction = Direction.Left;
                        break;
                    case PointType.VerticalSplitter:
                        Traverse(currentPoint.x, currentPoint.y, Direction.Down);

                        direction = Direction.Up;
                        break;
                }
            }

            nextPointInfo = _grid.TryTraverse(currentPoint.x, currentPoint.y, direction);
        }
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
}