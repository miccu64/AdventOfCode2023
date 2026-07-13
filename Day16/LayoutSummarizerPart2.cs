namespace Day16;

public class LayoutSummarizerPart2(string fileName)
{
    public int Traverse()
    {
        Layout tempLayout = new(fileName);
        int xLength = tempLayout.XLength;
        int yLength = tempLayout.YLength;

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