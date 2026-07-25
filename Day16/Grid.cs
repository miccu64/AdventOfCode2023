using Day16.Models;

namespace Day16;

public class Grid<T>
{
    private readonly T[,] _layout;

    public int Width => _layout.GetLength(0);
    public int Height => _layout.GetLength(1);
    public IEnumerable<T> AllPoints => _layout.Cast<T>();
    public T this[int x, int y] => _layout[y, x];

    public Grid(string fileName, Func<char, T> cellBuilder)
    {
        string[] text = File.ReadAllLines(fileName);

        int width = text[0].Length;
        int height = text.Length;

        _layout = new T[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _layout[x, y] = cellBuilder(text[x][y]);
            }
        }
    }

    public (T point, int x, int y)? TryTraverse(int x, int y, Direction direction)
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
            T point = this[newCoordinates.x, newCoordinates.y];
            return (point, newCoordinates.x, newCoordinates.y);
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }
}