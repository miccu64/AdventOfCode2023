namespace Day06.Models
{
    internal class Race
    {
        public long MaxTime { get; private set; }
        public long MaxDistance { get; private set; }

        private readonly List<long> WinningPressingTimes = new();

        private readonly long AccelerationRatio = 1;

        public Race(long _time, long _distance)
        {
            MaxTime = _time;
            MaxDistance = _distance;

            for (long pressTime = 1; pressTime < MaxTime - 1; pressTime++)
            {
                long acceleration = AccelerationRatio * pressTime;
                long distance = acceleration * (MaxTime - pressTime);
                if (distance>MaxDistance)
                    WinningPressingTimes.Add(pressTime);
            }
        }

        public long GetWinningPressingTimesCount()
        {
            return WinningPressingTimes.Count;
        }
    }
}
