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
                ulong destinationRangeStart = ulong.Parse(splittedLine[0]);
                ulong sourceRangeStart = ulong.Parse(splittedLine[1]);
                ulong rangeLength = ulong.Parse(splittedLine[2]);

                SourceToDestinationRanges.Add(new Range(sourceRangeStart, destinationRangeStart, rangeLength));
            }
        }

        public ulong GetDestinationValue(ulong sourceValue)
        {
            foreach (Range range in SourceToDestinationRanges)
            {
                if (range.TryGetDestinationValue(sourceValue, out ulong destinationValue))
                    return destinationValue;
            }

            return sourceValue;
        }
    }
}
