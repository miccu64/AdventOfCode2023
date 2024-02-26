namespace Day07.Models
{
    internal class Card : IComparable<Card>
    {
        public char Label { get; private set; }
        public int Power { get; protected set; }

        public Card(char label)
        {
            Power = label switch
            {
                '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => int.Parse(label.ToString()),
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new ArgumentException("Wrong label: " + label),
            };
            Label = label;
        }

        public int CompareTo(Card? other)
        {
            return Power - (other?.Power ?? 0);
        }
    }
}
