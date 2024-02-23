using System.Diagnostics;

namespace Day05.Models
{
    internal class AlmanacPart2 : Almanac
    {
        public AlmanacPart2(string fileName) : base(fileName) { }

        public new long FindLowestLocationNumber()
        {
            long lowestLocationNumber = long.MaxValue;
            ReaderWriterLockSlim lockSlim = new();

            for (int i = 0; i < Seeds.Count; i += 2)
            {
                Console.WriteLine("Loop: " + i / 2);

                long startSeed = Seeds[i];
                long rangeLength = Seeds[i + 1];
                long rangeEnd = startSeed + rangeLength;

                Parallel.For(startSeed, rangeEnd, seed =>
                {
                    long latestValue = seed;
                    foreach (Map map in Maps)
                        latestValue = map.GetDestinationValue(latestValue);

                    lockSlim.EnterReadLock();
                    long copyLowestLocationNumber = lowestLocationNumber;
                    lockSlim.ExitReadLock();

                    if (latestValue < copyLowestLocationNumber)
                    {
                        lockSlim.EnterWriteLock();

                        if (latestValue < lowestLocationNumber)
                            lowestLocationNumber = latestValue;

                        lockSlim.ExitWriteLock();
                        Console.WriteLine("New lowest location value: " + latestValue);
                    }
                });
            }

            return lowestLocationNumber;
        }
    }
}
