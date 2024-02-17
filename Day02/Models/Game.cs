namespace Day02.Models
{
    internal struct Game
    {
        public uint Id { get; private set; }
        public bool IsGamePossible { get; private set; }
        public uint GamePower { get; private set; }

        public Game(string info)
        {
            string[] splittedInfo = info.Split(':');
            string idString = splittedInfo.First().Replace("Game ", "");
            Id = uint.Parse(idString);

            string[] splittedCubeSetsInfo = splittedInfo[1].Split(';');
            List<CubesSet> cubesSets = splittedCubeSetsInfo.Select(cubeSetInfo => new CubesSet(cubeSetInfo.Trim())).ToList();

            IsGamePossible = cubesSets.All(cubeSet => cubeSet.IsSetPossible);

            uint redMax = cubesSets.Max(c => c.RedCount);
            uint blueMax = cubesSets.Max(c => c.BlueCount);
            uint greenMax = cubesSets.Max(c => c.GreenCount);

            GamePower = redMax * blueMax * greenMax;
        }
    }
}
