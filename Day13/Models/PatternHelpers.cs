namespace Day13.Models;

public static class PatternHelpers
{
    public static int GetSummary(string fileName, bool isPart2 = false)
    {
        return LoadPatterns(fileName, isPart2).Sum(p => p.FindReflection());
    }

    private static List<Pattern> LoadPatterns(string fileName, bool isPart2)
    {
        List<Pattern> patterns = [];
        string[] textLines = File.ReadAllLines(fileName);

        int pos = 0;
        while (pos < textLines.Length)
        {
            List<string> singlePatternTextLines = [];

            while (pos < textLines.Length && !string.IsNullOrWhiteSpace(textLines[pos]))
            {
                singlePatternTextLines.Add(textLines[pos]);
                pos++;
            }

            patterns.Add(isPart2
                ? new PatternPart2(singlePatternTextLines)
                : new Pattern(singlePatternTextLines)
            );

            pos++;
        }

        return patterns;
    }
}