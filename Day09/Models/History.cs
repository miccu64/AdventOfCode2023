namespace Day09.Models
{
    internal class History
    {
        private readonly List<List<int>> Differences;

        public History(string data)
        {
            List<int> firstLine = data.Split(' ').Select(int.Parse).ToList();
            Differences = new() { firstLine };
        }

        public int GetLatestValue()
        {
            DoDifferences();
            Extrapolate();
            return Differences.First().Last();
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
            Differences.Last().Add(0);

            for (int i = Differences.Count - 1; i > 0; i--)
            {
                List<int> lineLower = Differences[i];
                List<int> lineUpper = Differences[i - 1];
                lineUpper.Add(lineLower.Last() + lineUpper.Last());
            }
        }
    }
}
