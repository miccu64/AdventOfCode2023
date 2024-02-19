namespace Day04.Models
{
    internal class Card
    {
        public int Points { get; private set; }

        public Card(string info)
        {
            string[] allNumbersInfo = info.Split(':')[1].Trim().Split('|');
            string winningNumbersInfo = allNumbersInfo[0].Trim();
            string cardNumbersInfo = allNumbersInfo[1].Trim();

            List<int> winningNumbers = ParseNumbers(winningNumbersInfo);
            List<int> cardNumbers = ParseNumbers(cardNumbersInfo);

            List<int> matchNumbers = winningNumbers.Intersect(cardNumbers).ToList();
            Points = matchNumbers.Count > 0 ?
                (int)Math.Pow(2, matchNumbers.Count - 1) :
                0;
        }

        private List<int> ParseNumbers(string info)
        {
            return info.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
