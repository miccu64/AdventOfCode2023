namespace Day15.Models.Part2;

public class Box(int index)
{
    public int Index { get; } = index;
    public IList<Lens> Lenses { get; } = [];
}