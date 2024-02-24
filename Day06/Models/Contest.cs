namespace Day06.Models
{
    internal class Contest
    {
        public readonly List<Race> races = new();

        public Contest(string fileName)
        {
            string[] text = File.ReadAllLines(fileName);
            long[] times = GetNumbers(text[0]);
            long[] distance = GetNumbers(text[1]);

            for (long i = 0; i < times.Length; i++)
                races.Add(new Race(times[i], distance[i]));
        }

        public long GetWinningCountMultiplied()
        {
            long result = 1;
            foreach (Race race in races)
                result *= race.GetWinningPressingTimesCount();

            return result;
        }

        protected virtual long[] GetNumbers(string text)
        {
            return text.Split(':')[1].Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(str => long.Parse(str.Trim()))
                .ToArray();
        }
    }
}
