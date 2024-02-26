namespace Day07.Models
{
    internal class Game
    {
        public readonly List<Hand> Hands = new();
        public int Result { get; private set; }

        public Game(string fileName)
        {
            string[] data = File.ReadAllLines(fileName);
            foreach (string line in data)
                Hands.Add(CreateHand(line));

            Hands.Sort();

            Result = 0;
            for (int i = 1; i <= Hands.Count; i++)
                Result += i * Hands[i - 1].PointsToMultiply;
        }

        protected virtual Hand CreateHand(string line)
        {
            return new Hand(line);
        }
    }
}
