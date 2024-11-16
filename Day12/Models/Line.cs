namespace Day12.Models
{
    internal class Line
    {
        public readonly int ArrangementsCount;

        private readonly IList<bool?> _springsStatuses;
        private readonly IList<int> _damagedGroups;

        public Line(string line)
        {
            string[] splitLine = line.Split(' ');

            _springsStatuses = GetSpringsStatuses(splitLine[0]);
            _damagedGroups = GetDamagedGroups(splitLine[1]);

            ArrangementsCount = GetArrangementsCount();
        }

        protected virtual IList<bool?> GetSpringsStatuses(string data)
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

        protected virtual IList<int> GetDamagedGroups(string data)
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

        private int GetArrangementsCount(IList<int> previousUnknownSpringsIds, IList<bool?> previousStatuses)
        {
            if (previousUnknownSpringsIds.Count == 0)
                return IsProperArrangement(previousStatuses) == true ? 1 : 0;

            Queue<int> remainingUnknownSpringsIds = new(previousUnknownSpringsIds);
            int unknownId = remainingUnknownSpringsIds.Dequeue();

            List<bool> availableValues = [false, true];
            return availableValues.Sum(value =>
            {
                List<bool?> currentStatuses = new(previousStatuses);
                currentStatuses[unknownId] = value;

                if (IsProperArrangement(currentStatuses) == false)
                    return 0;

                return GetArrangementsCount(remainingUnknownSpringsIds.ToList(), currentStatuses);
            });
        }

        private bool? IsProperArrangement(IList<bool?> statuses)
        {
            List<int> damagedInRowCounts = [];

            int damagedInRowCount = 0;
            for (int i = 0; i < statuses.Count; i++)
            {
                bool? status = statuses[i];

                if (status == null)
                    return AreDamagedGroupsStartingWith(damagedInRowCounts) ? null : false;

                if (status.Value)
                {
                    if (damagedInRowCount > 0)
                        damagedInRowCounts.Add(damagedInRowCount);

                    damagedInRowCount = 0;
                }
                else
                {
                    damagedInRowCount++;
                }
            }

            if (damagedInRowCount > 0)
                damagedInRowCounts.Add(damagedInRowCount);

            return damagedInRowCounts.SequenceEqual(_damagedGroups);
        }

        private bool AreDamagedGroupsStartingWith(IList<int> subvalues)
        {
            if (subvalues.Count > _damagedGroups.Count)
                return false;

            for (int i = 0; i < subvalues.Count; i++)
            {
                if (_damagedGroups[i] != subvalues[i])
                    return false;
            }

            return true;
        }
    }
}
