namespace Day11.Models
{
    internal class Image
    {
        protected readonly int ExpandRatio;

        private readonly List<Galaxy> Galaxies = [];
        private readonly List<Tuple<Galaxy, Galaxy>> Permutations = [];
        private readonly Galaxy Size = new();

        public Image(string fileName, int expandRatio)
        {
            ExpandRatio = expandRatio - 1;

            PopulateGalaxies(fileName);
            ExpandEmptyRowsAndColumns();
            GetUniquePermutations();
        }

        public ulong FindSumOfShortestPaths()
        {
            ulong result = 0;
            foreach (var permutation in Permutations)
                result += AbsSubtract(permutation.Item1.X, permutation.Item2.X) + AbsSubtract(permutation.Item1.Y, permutation.Item2.Y);

            return result;
        }

        private static ulong AbsSubtract(int item1, int item2)
        {
            long result = item1 - item2;
            return (ulong)(result >= 0 ? result : result * (-1));
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

            List<Tuple<int, int>> xyToAdd = [];

            foreach (Galaxy galaxy in Galaxies)
            {
                int earlierFreeXCount = freeX.Count(x => x < galaxy.X);
                int earlierFreeYCount = freeY.Count(y => y < galaxy.Y);

                xyToAdd.Add(new Tuple<int, int>(earlierFreeXCount, earlierFreeYCount));
            }

            for (int i = 0; i < Galaxies.Count; i++)
            {
                Galaxy galaxy = Galaxies[i];
                Tuple<int, int> xy = xyToAdd[i];
                galaxy.X += xy.Item1 * ExpandRatio;
                galaxy.Y += xy.Item2 * ExpandRatio;
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
