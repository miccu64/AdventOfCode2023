namespace Day18.Models;

public class LagoonEdge : LagoonInterior
{
    public string HexColor { get; }

    public LagoonEdge(string hexColor)
    {
        HexColor = hexColor;
        MarkAsDugOut();
    }
}