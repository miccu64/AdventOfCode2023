namespace Day04.Models
{
    internal class Card
    {
        public int Id { get; private set; }
        public int Points { get; private set; }
        public int MatchNumbersCount { get; private set; }

        public Card(string info)
        {
            string[] splittedInfo = info.Split(':');
            string idInfo = splittedInfo[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Last();
            Id = int.Parse(idInfo);

            string[] allNumbersInfo = splittedInfo[1].Trim().Split('|');
            string winningNumbersInfo = allNumbersInfo[0].Trim();
            string cardNumbersInfo = allNumbersInfo[1].Trim();

            List<int> winningNumbers = ParseNumbers(winningNumbersInfo);
            List<int> cardNumbers = ParseNumbers(cardNumbersInfo);

            List<int> matchNumbers = winningNumbers.Intersect(cardNumbers).ToList();
            Points = matchNumbers.Count > 0 ?
                (int)Math.Pow(2, matchNumbers.Count - 1) :
                0;
            MatchNumbersCount = matchNumbers.Count;
        }

        public static long FindWonCardsCount(List<int> cardsIdsToIterate, Dictionary<int, Card> allCards)
        {
            long count = cardsIdsToIterate.Count;
            int divisor = allCards.Count;
            foreach (int cardId in cardsIdsToIterate)
            {
                Card card = allCards[cardId];
                List<int> wonCardIds = new();
                for (int i = 0; i < card.MatchNumbersCount; i++)
                {
                    int id = ((card.Id + i) % divisor) + 1;
                    wonCardIds.Add(id);
                }

                count += FindWonCardsCount(wonCardIds, allCards);
            }

            return count;
        }

        private List<int> ParseNumbers(string info)
        {
            return info.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
