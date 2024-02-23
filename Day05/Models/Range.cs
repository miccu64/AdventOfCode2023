namespace Day05.Models
{
    internal class Range
    {
        public long SourceRangeStart { get; private set; }
        public long DestinationRangeStart { get; private set; }
        public long RangeLength { get; private set; }

        public Range(long sourceRangeStart, long destinationRangeStart, long rangeLength)
        {
            SourceRangeStart = sourceRangeStart;
            DestinationRangeStart = destinationRangeStart;
            RangeLength = rangeLength;
        }

        public bool TryGetDestinationValue(long sourceValue, out long destinationValue)
        {
            if (sourceValue < SourceRangeStart || sourceValue >= SourceRangeStart + RangeLength)
            {
                destinationValue = 0;
                return false;
            }

            long difference = sourceValue - SourceRangeStart;
            destinationValue = DestinationRangeStart + difference;
            return true;
        }
    }
}
