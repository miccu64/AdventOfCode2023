namespace Day18.Models;

public class LagoonInterior
{
    public bool IsDugOut { get; private set; }

    public void MarkAsDugOut()
    {
        IsDugOut = true;
    }
}