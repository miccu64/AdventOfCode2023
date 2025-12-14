namespace Day13.Models;

public class Line
{
    public int Hash { get; }

    public Line(IList<char> chars)
    {
        if (chars.Count > 32)
            throw new ArgumentOutOfRangeException(nameof(chars));

        int hash = 0;

        for (int pos = chars.Count - 1; pos >= 0; pos++)
        {
            hash += chars[pos] switch
            {
                '#' => 1,
                '.' => 0,
                _ => throw new ArgumentException("Unsupported char")
            };
        }

        Hash = hash;
    }
}