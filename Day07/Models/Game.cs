namespace Day07.Models
{
    internal class Game
    {
        public readonly List<Hand> Hands = new();

        public Game(string fileName)
        {
            string[] data = File.ReadAllLines(fileName);
            foreach (string line in data)
                Hands.Add(new Hand(line));
        }
    }
}
