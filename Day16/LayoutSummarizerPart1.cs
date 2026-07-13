namespace Day16;

public class LayoutSummarizerPart1(string fileName)
{
    public int Traverse()
    {
        Layout layout = new(fileName);
        return layout.Traverse(-1, 0);
    }
}