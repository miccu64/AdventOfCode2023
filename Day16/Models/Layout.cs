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
        Traverse(0, 0, Direction.Right);
    }

    private void Traverse(int startX, int startY, Direction direction)
    {
    }

    private (int x, int y)? GetNextPointCoordinates(int x, int y, Direction direction)
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
            Point _ = _layout[newCoordinates.x, newCoordinates.y];
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }

        return newCoordinates;
    }
}