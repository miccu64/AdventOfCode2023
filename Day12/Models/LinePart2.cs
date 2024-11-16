namespace Day12.Models
{
    internal class LinePart2(string line) : Line(line)
    {
        private readonly int _multiplier = 5;

        protected override IList<bool?> GetSpringsStatuses(string data)
        {
            IList<bool?> statuses = base.GetSpringsStatuses(data);

            List<bool?> unfoldedStatuses = [];
            for (int i = 0; i < _multiplier; i++)
                unfoldedStatuses.AddRange(statuses);

            return unfoldedStatuses;
        }

        protected override IList<int> GetDamagedGroups(string data)
        {
            IList<int> groups = base.GetDamagedGroups(data);

            List<int> unfoldedGroups = [];
            for (int i = 0; i < _multiplier; i++)
                unfoldedGroups.AddRange(groups);

            return unfoldedGroups;
        }
    }
}
