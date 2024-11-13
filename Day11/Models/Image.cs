namespace Day11.Models
{
    internal class Image
    {
        private readonly List<Galaxy> Galaxies = [];
        private readonly List<Tuple<Galaxy, Galaxy>> Permutations = [];
        private readonly Galaxy Size = new();

        public Image(string fileName)
        {
            PopulateGalaxies(fileName);
            ExpandEmptyRowsAndColumns();
            GetUniquePermutations();
        }

        public int FindSumOfShortestPaths()
        {
            return Permutations.Select(permutation =>
                Math.Abs(permutation.Item1.X - permutation.Item2.X) + Math.Abs(permutation.Item1.Y - permutation.Item2.Y)
            ).Sum();
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
                        Galaxies.Add(new Galaxy { X = x, Y = y });
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
                foreach (Galaxy coordinate in Galaxies)
                {
                    if (x <= (coordinate.X - i))
                        coordinate.X++;
                }
            }

            for (int i = 0; i < freeY.Count; i++)
            {
                int y = freeY[i];
                foreach (Galaxy coordinate in Galaxies)
                {
                    if (y < coordinate.Y - i)
                        coordinate.Y++;
                }
            }
        }

        private void ExpandCoordinates(List<int> freeCoordinates, List<int> usedCoordinates, Action<Galaxy, int> updateCoordinate)
        {
            for (int i = 0; i < freeCoordinates.Count; i++)
            {
                int x = freeCoordinates[i];
                foreach (Galaxy galaxy in Galaxies)
                {
                    if (x <= (galaxy.X - i))
                        galaxy.X++;
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

        private void GetUniquePermutations()
        {
            foreach (Galaxy coordinate in Galaxies)
            {
                List<Galaxy> galaxiesWithFartherCoordinates = Galaxies.Where(galaxy =>
                    coordinate.Y < galaxy.Y || (coordinate.Y == galaxy.Y && coordinate.X < galaxy.X)
                ).ToList();

                Permutations.AddRange(galaxiesWithFartherCoordinates.Select(galaxy =>
                    new Tuple<Galaxy, Galaxy>(coordinate, galaxy))
                );
            }
        }
    }
}
