namespace Day15.Models;

public class Hasher
{
    private const int Multiplier = 17;

    public long Hash(string text)
    {
        return text.Split(',')
            .Select(stepText => (long)HashStep(stepText))
            .Sum();
    }

    private static int HashStep(string stepText)
    {
        const int maxAsciiValue = 256;
        int result = 0;

        foreach (char c in stepText)
        {
            result += c;
            result = result * Multiplier % maxAsciiValue;
        }

        return result;
    }
}