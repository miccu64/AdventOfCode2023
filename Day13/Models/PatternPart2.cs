namespace Day13.Models;

public class PatternPart2(IReadOnlyList<string> horizontalTexts) : Pattern(horizontalTexts)
{
    private bool _smudgeAlreadyReplaced;

    protected override bool IsReflection(IReadOnlyList<Line> lines, int startIndex)
    {
        _smudgeAlreadyReplaced = false;

        bool result = base.IsReflection(lines, startIndex);

        return result && _smudgeAlreadyReplaced;
    }

    protected override bool AreLinesEqual(Line line1, Line line2)
    {
        int bitDifferences = 0;
        const int intBitsCount = 32;
        int xor = line1.Hash ^ line2.Hash;

        for (int i = 0; i < intBitsCount; i++)
        {
            bool bitDiffer = (xor & (1 << i)) != 0;
            if (!bitDiffer)
                continue;

            bitDifferences++;
            if (bitDifferences > 1)
                return false;
        }

        if (bitDifferences != 1)
            return true;
        if (_smudgeAlreadyReplaced)
            return false;

        _smudgeAlreadyReplaced = true;

        return true;
    }
}