namespace Day05.Models
{
    internal class AlmanacPart2 : Almanac
    {
        public AlmanacPart2(string fileName) : base(fileName) { }

        public new ulong FindLowestLocationNumber()
        {
            ulong lowestLocationNumber = ulong.MaxValue;

            for (int i = 0; i < Seeds.Count; i += 2)
            {
                ulong currentSeed = Seeds[i];
                ulong rangeLength = Seeds[i + 1];
                ulong rangeEnd = currentSeed + rangeLength - 1;

                while (currentSeed <= rangeEnd)
                {
                    ulong latestValue = currentSeed;
                    foreach (Map map in Maps)
                        latestValue = map.GetDestinationValue(latestValue);

                    if (latestValue < lowestLocationNumber)
                        lowestLocationNumber = latestValue;

                    currentSeed++;
                }
            }

            return lowestLocationNumber;
        }
    }
}
