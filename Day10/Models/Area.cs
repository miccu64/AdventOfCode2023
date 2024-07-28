namespace Day10.Models
{
    internal class Area
    {
        private readonly Tile[,] Tiles;

        public Area(string fileName)
        {
            Tiles = LoadTilesFromFile(fileName);
            TraverseForOrders();
        }

        public int FarthestTileOrder()
        {
            int maxOrder = Tiles.Cast<Tile>().Select(tile => tile.Order).Max() ?? -1;
            if (maxOrder % 2 != 0)
                throw new Exception("Wrong max order!");

            return maxOrder / 2;
        }

        private static Tile[,] LoadTilesFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            Tile[,] tiles = new Tile[lines[0].Length, lines.Length];

            for (int y = 0; y < lines.Length; y++)
            {
                char[] chars = lines[y].ToCharArray();
                for (int x = 0; x < chars.Length; x++)
                {
                    tiles[x, y] = new Tile(chars[x], x, y);
                }
            }

            return tiles;
        }

        private void TraverseForOrders()
        {
            Tile previousTile = Tiles.Cast<Tile>().Single(tile => tile.Sign == SignEnum.Start);
            Tile currentTile;

            do
            {
                currentTile = FindAdjacentTile(previousTile);
                //Console.WriteLine($"({previousTile.X},{previousTile.Y}) -> ({currentTile.X},{currentTile.Y})");

                currentTile.Order = previousTile.Order + 1;

                previousTile = currentTile;
            } while (currentTile.Sign != SignEnum.Start);
        }

        private Tile FindAdjacentTile(Tile currentTile)
        {
            int x = currentTile.X;
            int y = currentTile.Y;

            List<Tile?> adjacentTiles = new()
            {
                TryGetTile(x-1, y),
                TryGetTile(x+1, y),
                TryGetTile(x, y-1),
                TryGetTile(x, y+1),
            };

            foreach (Tile? tile in adjacentTiles)
            {
                bool canTileConnectToStartPoint = tile?.Sign == SignEnum.Start && currentTile.Order > 1;
                if (tile != null && TilesConnect(currentTile, tile) && (tile.Order == null || canTileConnectToStartPoint))
                {
                    return tile;
                }
            }

            throw new Exception("No adjacent tile found!");
        }

        private Tile? TryGetTile(int x, int y)
        {
            try
            {
                return Tiles[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        private static bool TilesConnect(Tile tile1, Tile tile2)
        {
            int xDiff = tile2.X - tile1.X;
            int yDiff = tile2.Y - tile1.Y;

            if (xDiff == 0)
            {
                if (yDiff == 1)
                {
                    return tile1.DownConnect && tile2.UpConnect;
                }
                else if (yDiff == -1)
                {
                    return tile1.UpConnect && tile2.DownConnect;
                }
            }
            else if (yDiff == 0)
            {
                if (xDiff == 1)
                {
                    return tile1.RightConnect && tile2.LeftConnect;
                }
                else if (xDiff == -1)
                {
                    return tile1.LeftConnect && tile2.RightConnect;
                }
            }

            return false;
        }
    }
}
