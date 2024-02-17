namespace Day02.Models
{
    internal struct Game
    {
        public uint Id { get; private set; }
        public bool IsGamePossible { get; private set; }

        public Game(string info)
        {
            string[] splittedInfo = info.Split(':');
            string idString = splittedInfo.First().Replace("Game ", "");
            Id = uint.Parse(idString);

            string[] splittedCubeSetsInfo = splittedInfo[1].Split(';');
            List<CubesSet> CubesSets = splittedCubeSetsInfo.Select(cubeSetInfo => new CubesSet(cubeSetInfo.Trim())).ToList();

            IsGamePossible = CubesSets.All(cubeSet => cubeSet.IsSetPossible);
        }
    }
}
