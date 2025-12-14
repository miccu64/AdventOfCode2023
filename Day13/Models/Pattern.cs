namespace Day13.Models;

public class Pattern
{
    private readonly List<Line> _verticalLines;
    private readonly List<Line> _horizontalLines;

    public Pattern(IReadOnlyList<string> horizontalTexts)
    {
        _horizontalLines = horizontalTexts
            .Select(text => new Line(text))
            .ToList();

        _verticalLines = [];

        int verticalLinesCount = horizontalTexts[0].Length;
        for (int i = 0; i < verticalLinesCount; i++)
        {
            string verticalText = string.Join("", horizontalTexts.Select(text => text[i]));
            _verticalLines.Add(new Line(verticalText));
        }
    }

    public int FindReflection()
    {
        int horizontalResult = FindReflection(_horizontalLines);
        int verticalResult = FindReflection(_verticalLines);

        return horizontalResult > verticalResult
            ? horizontalResult * 100
            : verticalResult;
    }

    protected virtual bool IsReflection(IReadOnlyList<Line> lines, int startIndex)
    {
        int leftLinesCount = startIndex + 1;
        int rightLinesCount = lines.Count - startIndex - 1;
        int linesFromBothSidesCount = Math.Min(leftLinesCount, rightLinesCount);

        for (int bothSidesDiff = 0; bothSidesDiff < linesFromBothSidesCount; bothSidesDiff++)
        {
            int leftIndex = startIndex - bothSidesDiff;
            int rightIndex = startIndex + 1 + bothSidesDiff;
            if (AreLinesEqual(lines[leftIndex], lines[rightIndex]))
                continue;

            return false;
        }

        return true;
    }

    protected virtual bool AreLinesEqual(Line line1, Line line2)
    {
        return line1.Hash == line2.Hash;
    }

    private int FindReflection(List<Line> lines)
    {
        List<int> allReflections = [];

        for (int startIndex = 0; startIndex < lines.Count - 1; startIndex++)
        {
            if (IsReflection(lines, startIndex))
                allReflections.Add(startIndex);
        }

        return allReflections.Count == 0
            ? 0
            : allReflections.Max() + 1;
    }
}