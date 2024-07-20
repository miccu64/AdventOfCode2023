namespace Day09.Models
{
    internal class History
    {
        private readonly List<List<int>> Differences;

        public History(string data)
        {
            List<int> firstLine = data.Split(' ').Select(int.Parse).ToList();
            Differences = new() { firstLine };

            DoDifferences();
            Extrapolate();
        }

        public int GetLatestValue()
        {
            return Differences.First().Last();
        }

        public int GetFirstValue()
        {
            return Differences.First().First();
        }

        private void DoDifferences()
        {
            List<int> line = Differences.Last();
            do
            {
                List<int> leftValues = line.SkipLast(1).ToList();
                List<int> rightValues = line.Skip(1).ToList();
                line = leftValues.Zip(rightValues, (left, right) => right - left).ToList();
                Differences.Add(line);
            }
            while (line.Any(x => x != 0));
        }

        private void Extrapolate()
        {
            Differences.Last().Insert(0, 0);
            Differences.Last().Add(0);

            for (int i = Differences.Count - 1; i > 0; i--)
            {
                List<int> lineLower = Differences[i];
                List<int> lineUpper = Differences[i - 1];
                lineUpper.Insert(0, lineUpper.First() - lineLower.First());
                lineUpper.Add(lineLower.Last() + lineUpper.Last());
            }
        }
    }
}
