namespace Day16.Models;

public class Layout
{
    private readonly Point[,] _layout;

    public Layout(string fileName)
    {
        string[] text = File.ReadAllLines(fileName);

        int yLength = text.Length;
        int xLength = text[0].Length;
        _layout = new Point[yLength, xLength];

        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < xLength; x++)
            {
                _layout[y, x] = new Point(text[y][x]);
            }
        }
    }

    public void Traverse()
    {
        Traverse(0, 0, Direction.Right);
    }

    private void Traverse(int startY, int startX, Direction direction)
    {
    }

    private (int y, int x) GetNextPointCoordinates(int y, int x, Direction direction)
    {
        (int newY, int newX) newCoordinates = direction switch
        {
            Direction.Up => (y - 1, x),
            Direction.Down => (y + 1, x),
            Direction.Left => (y, x - 1),
            Direction.Right => (y, x + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
        try
        {
            Point _ = _layout[y, x];
        }
        catch (IndexOutOfRangeException)
        {
            return (-1, -1);
        }

        return newCoordinates;
    }
}