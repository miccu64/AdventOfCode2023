namespace Day05.Models
{
    internal class Map
    {
        public string Name { get; private set; }

        private readonly List<Range> Ranges = new();

        public Map(string[] data)
        {
            Name = data[0].Trim()[..^5];

            for (int i = 1; i < data.Length; i++)
            {
                string[] splittedLine = data[i].Trim().Split(' ');
                long destinationRangeStart = long.Parse(splittedLine[0]);
                long sourceRangeStart = long.Parse(splittedLine[1]);
                long rangeLength = long.Parse(splittedLine[2]);

                Ranges.Add(new Range(destinationRangeStart, sourceRangeStart, rangeLength));
            }
        }

        public long GetDestinationValue(long sourceValue)
        {
            foreach (Range range in Ranges)
            {
                if (range.TryGetDestinationValue(sourceValue, out long destinationValue))
                    return destinationValue;
            }

            return sourceValue;
        }

        public long GetSourceValue(long destinationValue)
        {
            foreach (Range range in Ranges)
            {
                if (range.GetSourceValue(destinationValue, out long sourceValue))
                    return sourceValue;
            }

            return destinationValue;
        }

        public long FindMaxPossibleValue()
        {
            long max = 0;
            foreach (Range range in Ranges)
            {
                long start = range.DestinationRangeStart;
                long length = range.RangeLength;
                long end = start + length - 1;

                if (max < end)
                    max = end;
            }

            return max;
        }
    }
}
