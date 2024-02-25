namespace Day07.Models
{
    internal class Hand : IComparable<Hand>
    {
        public readonly List<Card> Cards = new();
        public int PointsToMultiply { get; private set; }
        public HandType Type { get; private set; }

        public Hand(string data)
        {
            string[] splittedData = data.Split(' ');

            foreach (char cardData in splittedData[0].Trim())
                Cards.Add(new Card(cardData));

            if (Cards.Count != 5)
                throw new Exception("Wrong card count");

            Type = FindHandType();

            PointsToMultiply = int.Parse(splittedData[1]);
        }

        public int CompareTo(Hand? other)
        {
            if (other == null)
                return 1;
            if (Type != other.Type)
                return Type - other.Type;
            for (int i = 0; i < Cards.Count; i++)
            {
                Card card1 = Cards[i];
                Card card2 = other.Cards[i];
                int compareResult = card1.CompareTo(card2);
                if (compareResult != 0)
                    return compareResult;
            }
            return 0;
        }

        private HandType FindHandType()
        {
            HandType type;
            var groupedCards = Cards.GroupBy(c => c.Power)
                .Select(x => new
                {
                    Power = x.Key,
                    Cards = x.ToArray()
                })
                .ToList();

            if (groupedCards.Count == 1)
                type = HandType.FiveOfAKind;
            else if (groupedCards.Any(x => x.Cards.Length == 4))
                type = HandType.FourOfAKind;
            else if (groupedCards.Any(x => x.Cards.Length == 3) && groupedCards.Any(x => x.Cards.Length == 2))
                type = HandType.FullHouse;
            else if (groupedCards.Any(x => x.Cards.Length == 3))
                type = HandType.ThreeOfAKind;
            else if (groupedCards.Where(x => x.Cards.Length == 2).Count() == 2)
                type = HandType.TwoPair;
            else if (groupedCards.Where(x => x.Cards.Length == 2).Count() == 1)
                type = HandType.OnePair;
            else
                type = HandType.HighCard;

            return type;
        }
    }
}
