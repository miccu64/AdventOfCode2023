using Day16.Extensions;

namespace Day16.Models;

public class Point(char c)
{
    public PointType Type { get; } = c.ToPointType();

    public bool IsEnergized { get; private set; }

    public void Energize()
    {
        IsEnergized = true;
    }
}