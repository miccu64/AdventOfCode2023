namespace Day14.Models;

public class Platform
{
    protected readonly CellType[,] Cells;
    protected readonly int Length;

    public Platform(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        Cells = new CellType[lines.Length, lines.First().Length];

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                Cells[y, x] = GetCellType(line[x]);
            }
        }

        Length = Cells.GetLength(0);
    }

    public long GetWeightAfterTiltNorth()
    {
        TiltNorth();
        return GetWeight();
    }

    protected long GetWeight()
    {
        long weight = 0;

        for (int x = 0; x < Length; x++)
        {
            for (int y = 0; y < Length; y++)
            {
                CellType cell = Cells[y, x];
                if (cell == CellType.MovableRock)
                    weight += Length - y;
            }
        }

        return weight;
    }

    protected void TiltNorth()
    {
        for (int x = 0; x < Length; x++)
        {
            int latestUsedY = -1;
            for (int y = 0; y < Length; y++)
            {
                CellType cell = GetCellForTilt(y, x);
                switch (cell)
                {
                    case CellType.Empty:
                        continue;
                    case CellType.MovableRock:
                        latestUsedY++;
                        SetCellForTilt(y, x, CellType.Empty);
                        SetCellForTilt(latestUsedY, x, CellType.MovableRock);
                        break;
                    case CellType.FixedRock:
                        latestUsedY = y;
                        break;
                    default:
                        throw new ArgumentException("Not supported cell type");
                }
            }
        }
    }

    protected virtual CellType GetCellForTilt(int y, int x)
    {
        return Cells[y, x];
    }

    protected virtual void SetCellForTilt(int y, int x, CellType cell)
    {
        Cells[y, x] = cell;
    }

    private static CellType GetCellType(char c)
    {
        return c switch
        {
            '.' => CellType.Empty,
            'O' => CellType.MovableRock,
            '#' => CellType.FixedRock,
            _ => throw new ArgumentException("Not supported cell type")
        };
    }
}