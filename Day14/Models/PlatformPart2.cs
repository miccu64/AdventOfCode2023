namespace Day14.Models;

public class PlatformPart2(string fileName) : Platform(fileName)
{
    private readonly List<long> _results = [];
    private TiltDirection _nextTiltDirection = TiltDirection.North;

    public long GetWeightAfterCycles(long cycles)
    {
        const int patternSearchInterval = 1000;
        for (long i = 1; i <= cycles; i++)
        {
            TiltNorth();
            _nextTiltDirection = TiltDirection.West;
            TiltNorth();
            _nextTiltDirection = TiltDirection.South;
            TiltNorth();
            _nextTiltDirection = TiltDirection.East;
            TiltNorth();
            _nextTiltDirection = TiltDirection.North;

            _results.Add(GetWeight());

            bool shouldCheckPatterns = i % patternSearchInterval == 0;
            if (!shouldCheckPatterns)
                continue;

            long? resultFromPattern = FindResultByPattern(i, cycles);
            if (resultFromPattern != null)
            {
                return resultFromPattern.Value;
            }
        }

        return GetWeight();
    }

    protected override CellType GetCellForTilt(int y, int x)
    {
        (int newY, int newX) = GetCoordinatesForTilt(y, x);
        return Cells[newY, newX];
    }

    protected override void SetCellForTilt(int y, int x, CellType cell)
    {
        (int newY, int newX) = GetCoordinatesForTilt(y, x);
        Cells[newY, newX] = cell;
    }

    private (int y, int x) GetCoordinatesForTilt(int y, int x)
    {
        // x1 = x * cos(fi) - y * sin(fi)
        // y1 = y * cos(fi) + x * sin(fi)
        // after rotation needed shift relative to length
        int shift = Length - 1;
        return _nextTiltDirection switch
        {
            TiltDirection.North => (y, x),
            TiltDirection.West => (-x + shift, y),
            TiltDirection.South => (-y + shift, -x + shift),
            TiltDirection.East => (x, -y + shift),
            _ => throw new ArgumentException("Not supported tilt type")
        };
    }

    private long? FindResultByPattern(long currentCycles, long expectedCycles)
    {
        List<long> results = _results.ToList();
        results.Reverse();

        _results.Clear();

        long latestResult = results[0];

        int patternLength = results.IndexOf(latestResult, 1);
        if (patternLength <= 0)
            return null;

        for (int i = 0; i < patternLength; i++)
        {
            bool patternInvalid = results[i] != results[i + patternLength];
            if (patternInvalid)
                return null;
        }

        int patternPosition = (int)((expectedCycles - currentCycles) % patternLength);
        return results[patternPosition];
    }
}