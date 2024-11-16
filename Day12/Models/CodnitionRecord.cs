namespace Day12.Models
{
    internal class ConditionRecord
    {
        private readonly ICollection<Line> _lines;

        public ConditionRecord(string fileName)
        {
            _lines = File.ReadLines(fileName).Select(CreateLine).ToList();
        }

        protected virtual Line CreateLine(string fileLine)
        {
            return new Line(fileLine);
        }

        public int SumArrangements()
        {
            return _lines.Sum(line => line.ArrangementsCount);
        }
    }
}
