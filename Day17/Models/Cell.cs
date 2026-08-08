namespace Day17.Models;

public class Cell(char c)
{
    public int Cost { get; } = int.Parse(c.ToString());
    public bool IsVisited { get; set; }
    public readonly List<TraversalInfo> TraversalInfos = [];
}