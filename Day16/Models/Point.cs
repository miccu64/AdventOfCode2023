namespace Day16.Models;

public class Point(char c)
{
    public PointType Type { get; } = c switch
    {
        '.' => PointType.EmptySpace,
        '/' => PointType.LeftToRightMirror,
        '\\' => PointType.RightToLeftMirror,
        '|' => PointType.VerticalSplitter,
        '-' => PointType.HorizontalSplitter,
        _ => throw new ArgumentException("Not supported char")
    };

    public bool IsEnergized { get; set; } = false;
}