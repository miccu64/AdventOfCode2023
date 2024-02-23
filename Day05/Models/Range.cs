namespace Day05.Models
{
    internal class Range
    {
        public ulong SourceRangeStart { get; private set; }
        public ulong DestinationRangeStart { get; private set; }
        public ulong RangeLength { get; private set; }

        public Range(ulong sourceRangeStart, ulong destinationRangeStart, ulong rangeLength)
        {
            SourceRangeStart = sourceRangeStart;
            DestinationRangeStart = destinationRangeStart;
            RangeLength = rangeLength;
        }

        public bool TryGetDestinationValue(ulong sourceValue, out ulong destinationValue)
        {
            if (sourceValue < SourceRangeStart || sourceValue >= SourceRangeStart + RangeLength)
            {
                destinationValue = 0;
                return false;
            }

            ulong difference = sourceValue - SourceRangeStart;
            destinationValue = DestinationRangeStart + difference;
            return true;
        }
    }
}
