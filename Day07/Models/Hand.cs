namespace Day07.Models
{
    internal class Hand
    {
        public readonly List<Card> Cards = new();
        public int Points { get; private set; }

        public Hand(string data)
        {
            string[] splittedData = data.Split(' ');

            foreach (char cardData in splittedData[0].Trim())
                Cards.Add(new Card(cardData));

            if (Cards.Count != 5)
                throw new Exception("Wrong card count");

            Points = int.Parse(splittedData[1]);
        }
    }
}
