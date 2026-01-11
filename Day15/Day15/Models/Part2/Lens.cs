namespace Day15.Models.Part2;

public class Lens(string label, int focalLength)
{
    public string Label { get; } = label;
    public int FocalLength { get; } = focalLength;
}