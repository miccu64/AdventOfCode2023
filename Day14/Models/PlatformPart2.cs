namespace Day14.Models;

public class PlatformPart2(string fileName) : Platform(fileName)
{
    private TiltDirection _nextTiltDirection = TiltDirection.North;

    public long GetWeightAfterCycles(long cycles)
    {
        for (long i = 0; i < cycles; i++)
        {
            TiltNorth();
            _nextTiltDirection = TiltDirection.West;
            TiltNorth();
            _nextTiltDirection = TiltDirection.South;
            TiltNorth();
            _nextTiltDirection = TiltDirection.East;
            TiltNorth();
            _nextTiltDirection = TiltDirection.North;
        }

        return GetWeight();
    }

    protected override CellType GetCellForTilt(int y, int x)
    {
        (int newY, int newX) = GetYXForTilt(y, x);
        return Cells[newY, newX];
    }

    protected override void SetCellForTilt(int y, int x, CellType cell)
    {
        (int newY, int newX) = GetYXForTilt(y, x);
        Cells[newY, newX] = cell;
    }

    private (int y, int x) GetYXForTilt(int y, int x)
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
}