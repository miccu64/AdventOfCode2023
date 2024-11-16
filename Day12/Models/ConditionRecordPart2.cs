namespace Day12.Models
{
    internal class ConditionRecordPart2(string fileName) : ConditionRecord(fileName)
    {
        protected override Line CreateLine(string fileLine)
        {
            var line = new LinePart2(fileLine);
            Console.WriteLine($"{fileLine} {line.ArrangementsCount}");
            return line;
           // return new LinePart2(fileLine);
        }
    }
}
