namespace Day17.Models;

public class Cell(char c)
{
    private const int UnvisitedDistance = -1;

    public int Cost { get; } = int.Parse(c.ToString());
    public int DistanceFromStart { get; set; } = UnvisitedDistance;
    public bool IsVisited => DistanceFromStart > UnvisitedDistance;
}