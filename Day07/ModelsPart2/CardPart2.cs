using Day07.Models;

namespace Day07.ModelsPart2
{
    internal class CardPart2 : Card
    {
        public CardPart2(char label) : base(label)
        {
            if (label == 'J')
                Power = 0;
        }
    }
}
