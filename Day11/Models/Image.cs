namespace Day11.Models
{
    internal class Image
    {
        private readonly List<Coordinate> Galaxies = [];
        private readonly Coordinate Size = new();

        public Image(string fileName)
        {
            PopulateGalaxies(fileName);
            ExpandEmptyRowsAndColumns();

            List<Tuple<Coordinate, Coordinate>> permutations = GetUniquePermutations();
        }

        private void PopulateGalaxies(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            Size.X = lines.Length;
            Size.Y = lines[0].Length;

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                        Galaxies.Add(new Coordinate { X = x, Y = y });
                }
            }
        }

        private void ExpandEmptyRowsAndColumns()
        {
            List<int> usedX = Galaxies.Select(galaxy => galaxy.X).Distinct().ToList();
            List<int> freeX = FindFreeNumbers(usedX, Size.X);

            List<int> usedY = Galaxies.Select(galaxy => galaxy.Y).Distinct().ToList();
            List<int> freeY = FindFreeNumbers(usedY, Size.Y);

            for (int i = 0; i < freeX.Count; i++)
            {
                int x = freeX[i];
                foreach (Coordinate coordinate in Galaxies)
                {
                    if (x <= (coordinate.X - i))
                        coordinate.X++;
                }
            }

            for (int i = 0; i < freeY.Count; i++)
            {
                int y = freeY[i];
                foreach (Coordinate coordinate in Galaxies)
                {
                    if (y < coordinate.Y - i)
                        coordinate.Y++;
                }
            }
        }

        private static List<int> FindFreeNumbers(List<int> numbers, int limit)
        {
            List<int> freeNumbers = [];

            for (int i = 0; i < limit; i++)
            {
                if (!numbers.Contains(i))
                    freeNumbers.Add(i);
            }

            return freeNumbers;
        }

        private List<Tuple<Coordinate, Coordinate>> GetUniquePermutations()
        {
            List<Tuple<Coordinate, Coordinate>> uniquePermutations = [];

            foreach (Coordinate coordinate in Galaxies)
            {
                List<Coordinate> galaxiesWithFartherCoordinates = Galaxies.Where(galaxy =>
                    coordinate.Y < galaxy.Y || (coordinate.Y == galaxy.Y && coordinate.X < galaxy.X)
                ).ToList();

                uniquePermutations.AddRange(galaxiesWithFartherCoordinates.Select(galaxy =>
                    new Tuple<Coordinate, Coordinate>(coordinate, galaxy))
                );
            }

            return uniquePermutations;
        }
    }
}
