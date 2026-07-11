using Day16.Models;

namespace Day16.Extensions;

public static class CharExtensions
{
    extension(char c)
    {
        public PointType ToPointType() => c switch
        {
            '.' => PointType.EmptySpace,
            '/' => PointType.SlashMirror,
            '\\' => PointType.BackslashMirror,
            '|' => PointType.VerticalSplitter,
            '-' => PointType.HorizontalSplitter,
            _ => throw new ArgumentException("Not supported char")
        };
    }
}