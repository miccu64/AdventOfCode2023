namespace Day13.Models;

public class Pattern
{
    private readonly List<Line> _verticalLines;
    private readonly List<Line> _horizontalLines;

    public static int GetSummary(string fileName)
    {
        return LoadPatterns(fileName).Sum(p => p.FindReflection());
    }

    private static List<Pattern> LoadPatterns(string fileName)
    {
        string[] textLines = File.ReadAllLines(fileName);
        List<Pattern> patterns = [];
        
        int pos = 0;
        while (pos < textLines.Length)
        {
            List<string> singlePatternTextLines = [];

            while (pos < textLines.Length && !string.IsNullOrWhiteSpace(textLines[pos]))
            {
                singlePatternTextLines.Add(textLines[pos]);
                pos++;
            }

            patterns.Add(new Pattern(singlePatternTextLines));
            pos++;
        }
        
        return patterns;
    }

    private Pattern(List<string> horizontalTexts)
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

    private int FindReflection()
    {
        int horizontalResult = 0;
        int verticalResult = 0;

        horizontalResult = FindReflection(_horizontalLines);
        verticalResult = FindReflection(_verticalLines);

        return Math.Max(horizontalResult, verticalResult);
    }

    private static int FindReflection(List<Line> lines)
    {
        List<int> allReflections = [];

        for (int leftIndex = 0; leftIndex < lines.Count - 1; leftIndex++)
        {
            int leftLinesCount = leftIndex;
            int rightLinesCount = lines.Count - leftIndex - 1;
            int linesFromBothSidesCount = Math.Min(leftLinesCount, rightLinesCount);

            bool isReflection = true;
            for (int bothSidesDiff = 0; bothSidesDiff < linesFromBothSidesCount; bothSidesDiff++)
            {
                int rightIndex = leftIndex + 1 + bothSidesDiff;
                if (lines[leftIndex].Hash != lines[rightIndex].Hash)
                {
                    isReflection = false;
                    break;
                }
            }

            if (isReflection)
                allReflections.Add(leftLinesCount);
        }

        return allReflections.Count == 0
            ? 0
            : allReflections.Max() + 1;
    }
}