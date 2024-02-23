namespace Day05.Models
{
    internal class Map
    {
        public string Name { get; private set; }

        public readonly Dictionary<ulong, ulong> SourceToDestination;

        public Map(string[] data)
        {
            SourceToDestination = new();
            for (ulong i = 0; i < 100; i++)
                SourceToDestination.Add(i, i);

            Name = data[0].Trim()[..^5];

            for (int i = 1; i < data.Length; i++)
            {
                string[] splittedLine = data[i].Trim().Split(' ');
                ulong destinationRangeStart = ulong.Parse(splittedLine[0]);
                ulong sourceRangeStart = ulong.Parse(splittedLine[1]);
                ulong rangeLength = ulong.Parse(splittedLine[2]);

                for (ulong offset = 0; offset < rangeLength; offset++)
                {
                    ulong source = sourceRangeStart + offset;
                    ulong destination = destinationRangeStart + offset;

                    SourceToDestination[source] = destination;
                }
            }
        }
    }
}
