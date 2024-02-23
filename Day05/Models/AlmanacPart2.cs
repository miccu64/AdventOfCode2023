namespace Day05.Models
{
    internal class AlmanacPart2 : Almanac
    {
        public AlmanacPart2(string fileName) : base(fileName) { }

        public override long FindLowestLocationNumber()
        {
            long result = 0;
            long maxPossibleLocation = FindMaxPossibleValue();

            for (long startLocation = 0; startLocation < maxPossibleLocation; startLocation++)
            {
                long latestValue = startLocation;
                for (int i = Maps.Count - 1; i >= 0; i--)
                    latestValue = Maps[i].GetSourceValue(latestValue);

                if (CheckSeedExistence(latestValue))
                {
                    result = startLocation;
                    break;
                }
            }

            return result;
        }

        private bool CheckSeedExistence(long seed)
        {
            for (int i = 0; i < Seeds.Count / 2; i++)
            {
                long start = Seeds[i * 2];
                long length = Seeds[i * 2 + 1];
                long end = start + length - 1;

                if (start <= seed && seed <= end)
                    return true;
            }

            return false;
        }

        private long FindMaxPossibleValue()
        {
            long max = 0;

            for (int i = 0; i < Seeds.Count / 2; i++)
            {
                long start = Seeds[i * 2];
                long length = Seeds[i * 2 + 1];
                long end = start + length - 1;

                if (max < end)
                    max = end;
            }

            foreach (Map map in Maps)
            {
                long value = map.FindMaxPossibleValue();
                if (max < value)
                    max = value;
            }

            return max;
        }
    }
}
