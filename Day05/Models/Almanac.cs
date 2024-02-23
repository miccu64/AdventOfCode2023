namespace Day05.Models
{
    internal class Almanac
    {
        public readonly List<long> Seeds;

        public readonly List<Map> Maps = new();

        public Almanac(string fileName)
        {
            string[] data = File.ReadAllLines(fileName).Append("").ToArray();

            string[] seedData = data[0].Split(' ')[1..];
            Seeds = seedData.Select(long.Parse).ToList();

            int currentStart = 2;
            for (int i = currentStart; i < data.Length; i++)
            {
                if (!string.IsNullOrEmpty(data[i]))
                    continue;

                Maps.Add(new Map(data[currentStart..i]));
                currentStart = i + 1;
            }
        }

        public virtual long FindLowestLocationNumber()
        {
            long lowestLocationNumber = long.MaxValue;

            foreach (long seed in Seeds)
            {
                long latestValue = seed;
                foreach (Map map in Maps)
                    latestValue = map.GetDestinationValue(latestValue);

                if (latestValue < lowestLocationNumber)
                    lowestLocationNumber = latestValue;
            }

            return lowestLocationNumber;
        }
    }
}
