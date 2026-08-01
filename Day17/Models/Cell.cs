namespace Day17.Models;

public class Cell(char c)
{
    public int Cost { get; } = int.Parse(c.ToString());
    public int DistanceFromStart { get; set; } = int.MaxValue;
    public bool IsVisited { get; set; }
    public MultipleLatestDirectionsQueuesWrapper QueuesWrapper { get; } = new();
}