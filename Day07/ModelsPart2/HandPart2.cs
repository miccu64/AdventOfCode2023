using Day07.Models;

namespace Day07.ModelsPart2
{
    internal class HandPart2 : Hand
    {
        public HandPart2(string data) : base(data) { }

        protected override CardPart2 CreateCard(char cardData)
        {
            return new CardPart2(cardData);
        }

        protected override HandType FindHandType()
        {
            HandType type = base.FindHandType();

            char[] noJokerLabels = Cards.Where(card => card.Power > 0)
                .Select(card => card.Label)
                .ToArray();

            int noJokerCount = noJokerLabels.Length;
            if (noJokerCount == 5)
                return type;
            if (noJokerCount == 0 || noJokerCount == 1)
                return HandType.FiveOfAKind;

            char[] possibleJokerReplacements = noJokerLabels.Distinct().ToArray();

            int jokerCount = 5 - noJokerCount;
            foreach (char c in possibleJokerReplacements)
            {
                string tempHandInfo = $"{string.Join("", noJokerLabels)}{c}{new string('J', jokerCount - 1)}{" 11"}";
                HandPart2 tempHand = new(tempHandInfo);
                if (type < tempHand.Type)
                    type = tempHand.Type;
            }

            return type;
        }
    }
}
