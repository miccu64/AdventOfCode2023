namespace Day12.Models
{
    internal class ConditionRecord
    {
        private readonly List<Line> _lines = [];

        public ConditionRecord(string fileName)
        {
            IEnumerable<string> fileLines = File.ReadLines(fileName);
            foreach (string fileLine in fileLines)
                _lines.Add(new Line(fileLine));
        }

        public int SumArrangements()
        {
            return _lines.Sum(line => line.ArrangementsCount);
        }
    }
}
