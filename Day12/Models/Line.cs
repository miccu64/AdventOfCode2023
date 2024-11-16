namespace Day12.Models
{
    internal class Line
    {
        public readonly int ArrangementsCount;

        private readonly List<bool?> _springsStatuses;
        private readonly List<int> _damagedGroups;

        public Line(string line)
        {
            string[] splitLine = line.Split(' ');

            _springsStatuses = GetSpringsStatuses(splitLine[0]);
            _damagedGroups = GetDamagedGroups(splitLine[1]);

            ArrangementsCount = GetArrangementsCount();
        }

        private static List<bool?> GetSpringsStatuses(string data)
        {
            List<bool?> statuses = [];

            foreach (char spring in data)
            {
                bool? isOperational = null;
                if (spring == '.')
                    isOperational = true;
                else if (spring == '#')
                    isOperational = false;

                statuses.Add(isOperational);
            }

            return statuses;
        }

        private static List<int> GetDamagedGroups(string data)
        {
            return data.Split(',').Select(int.Parse).ToList();
        }

        private int GetArrangementsCount()
        {
            List<int> unknownSpringsIds = _springsStatuses.Select((status, index) => status == null ? index : -1)
                .Where(id => id >= 0)
                .ToList();

            return GetArrangementsCount(unknownSpringsIds, _springsStatuses);
        }

        private int GetArrangementsCount(ICollection<int> previousUnknownSpringsIds, ICollection<bool?> previousStatuses)
        {
            if (previousUnknownSpringsIds.Count == 0)
                return IsProperArrangement(previousStatuses) ? 1 : 0;

            Queue<int> remainingUnknownSpringsIds = new(previousUnknownSpringsIds);
            int unknownId = remainingUnknownSpringsIds.Dequeue();

            List<bool> availableValues = [false, true];
            return availableValues.Sum(value =>
            {
                List<bool?> currentStatuses = new(previousStatuses);
                currentStatuses[unknownId] = value;

                return GetArrangementsCount(remainingUnknownSpringsIds.ToList(), currentStatuses);
            });
        }

        private bool IsProperArrangement(ICollection<bool?> statuses)
        {
            List<int> damagedInRowCounts = [];

            int damagedInRowCount = 0;
            foreach (bool? status in statuses)
            {
                if (status == null)
                    throw new ArgumentException("Found unknown status.");

                if (status.Value)
                {
                    damagedInRowCounts.Add(damagedInRowCount);
                    damagedInRowCount = 0;
                }
                else
                {
                    damagedInRowCount++;
                }
            }

            damagedInRowCounts.Add(damagedInRowCount);

            return damagedInRowCounts.Where(count => count > 0).SequenceEqual(_damagedGroups);
        }
    }
}
