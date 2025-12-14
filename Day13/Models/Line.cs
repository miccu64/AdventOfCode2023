namespace Day13.Models;

public class Line
{
    public int Hash { get; }

    public Line(string text)
    {
        if (text.Length > 32)
            throw new ArgumentOutOfRangeException(nameof(text));

        int hash = 0;

        for (int pos = 0; pos < text.Length; pos++)
        {
            bool isRock = text[pos] switch
            {
                '#' => true,
                '.' => false,
                _ => throw new ArgumentException("Unsupported char")
            };
            if (isRock)
                hash |= 1 << pos;
        }

        Hash = hash;
    }
}