using Day16.Models;

namespace Day16;

public class LayoutSummarizerPart2(string fileName)
{
    public int Traverse()
    {
        Grid<Point?> tempLayout = new(fileName, _ => null);
        int xLength = tempLayout.Width;
        int yLength = tempLayout.Height;

        List<(int x, int y)> startPoints =
            GenerateSingleDimensionStarts(xLength).Select(x => (x, -1))
                .Concat(GenerateSingleDimensionStarts(xLength).Select(x => (x, yLength)))
                .Concat(GenerateSingleDimensionStarts(xLength).Select(y => (-1, y)))
                .Concat(GenerateSingleDimensionStarts(xLength).Select(y => (xLength, y)))
                .ToList();

        return startPoints.AsParallel().Select(point => new Layout(fileName).Traverse(point.x, point.y))
            .Max();
    }

    private static IEnumerable<int> GenerateSingleDimensionStarts(int size)
    {
        return Enumerable.Range(0, size);
    }
}