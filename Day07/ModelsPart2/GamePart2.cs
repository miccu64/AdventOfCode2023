using Day07.Models;

namespace Day07.ModelsPart2
{
    internal class GamePart2 : Game
    {
        public GamePart2(string fileName) : base(fileName)
        {
        }

        protected override HandPart2 CreateHand(string line)
        {
            return new HandPart2(line);
        }
    }
}
