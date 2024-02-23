namespace Day05.Models
{
    internal class Map
    {
        public string Name { get; private set; }

        public readonly List<Range> SourceToDestinationRanges = new();

        public Map(string[] data)
        {
            Name = data[0].Trim()[..^5];

            for (int i = 1; i < data.Length; i++)
            {
                string[] splittedLine = data[i].Trim().Split(' ');
                long destinationRangeStart = long.Parse(splittedLine[0]);
                long sourceRangeStart = long.Parse(splittedLine[1]);
                long rangeLength = long.Parse(splittedLine[2]);

                SourceToDestinationRanges.Add(new Range(sourceRangeStart, destinationRangeStart, rangeLength));
            }
        }

        public long GetDestinationValue(long sourceValue)
        {
            foreach (Range range in SourceToDestinationRanges)
            {
                if (range.TryGetDestinationValue(sourceValue, out long destinationValue))
                    return destinationValue;
            }

            return sourceValue;
        }
    }
}
