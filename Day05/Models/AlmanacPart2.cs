namespace Day05.Models
{
    internal class AlmanacPart2 : Almanac
    {
        public AlmanacPart2(string fileName) : base(fileName) {}

        public override long FindLowestLocationNumber()
        {
            for (long startLocation = 0; startLocation < long.MaxValue; startLocation++)
            {
                long latestValue = startLocation;
                for (int i = Maps.Count - 1; i >= 0; i--)
                    latestValue = Maps[i].GetSourceValue(latestValue);

                if (CheckSeedExistence(latestValue))
                    return startLocation;
            }

            return 0;
        }

        private bool CheckSeedExistence(long seed)
        {
            for (int i = 0; i < Seeds.Count / 2; i++)
            {
                long start = Seeds[i * 2];
                long length = Seeds[i * 2 + 1];
                long end = start + length;

                if (start <= seed && seed < end)
                    return true;
            }

            return false;
        }
    }
}
