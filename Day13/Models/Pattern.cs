namespace Day13.Models;

public class Pattern
{
    private readonly List<Line> _lines;
    
    public static IEnumerable<Pattern> LoadPatterns(string fileName)
    {
        string[] textLines = File.ReadAllLines(fileName);

        int pos = 0;
        while (pos < textLines.Length)
        {
            List<Line> lines = [];

            while (!string.IsNullOrWhiteSpace(textLines[pos]))
            {
                lines.Add(new Line(textLines[pos].ToList()));
                pos++;
            }

            yield return new Pattern(lines);
        }
    }

    private Pattern(List<Line> lines)
    {
        _lines = lines;
    }
}