namespace Day05.Models
{
    internal class Range
    {
        public long DestinationRangeStart { get; private set; }
        public long SourceRangeStart { get; private set; }
        public long RangeLength { get; private set; }

        public Range(long destinationRangeStart, long sourceRangeStart, long rangeLength)
        {
            DestinationRangeStart = destinationRangeStart;
            SourceRangeStart = sourceRangeStart;
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

        public bool GetSourceValue(long destinationValue, out long sourceValue)
        {
            if (destinationValue < DestinationRangeStart || destinationValue >= DestinationRangeStart + RangeLength)
            {
                sourceValue = 0;
                return false;
            }

            long difference = destinationValue - DestinationRangeStart;
            sourceValue = SourceRangeStart + difference;
            return true;
        }
    }
}
