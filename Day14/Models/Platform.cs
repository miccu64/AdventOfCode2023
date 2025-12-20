namespace Day14.Models;

public class Platform
{
    private readonly CellType[,] _cells;

    public Platform(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        _cells = new CellType[lines.Length, lines.First().Length];

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                _cells[y, x] = GetCellType(line[x]);
            }
        }
    }

    public long GetWeightAfterTiltNorth()
    {
        long weight = 0;
        
        int xLength = _cells.GetLength(1);
        int yLength = _cells.GetLength(0);

        for (int x = 0; x < xLength; x++)
        {
            int latestUsedY = -1;
            for (int y = 0; y < yLength; y++)
            {
                CellType cell =  _cells[y, x];
                switch (cell)
                {
                    case CellType.Empty:
                        continue;
                    case CellType.MovableRock:
                        latestUsedY++;
                        weight += yLength - latestUsedY;
                        break;
                    case CellType.FixedRock:
                        latestUsedY = y;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }  
        }

        return  weight;
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