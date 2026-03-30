namespace WarGame.Core
{
    public class Cards
    {
        public static readonly string[] Values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        public static readonly string[] Suits = new string[] { "Hearts", "Diamonds", "Spades", "Clubs" };

        public string Suit { get; }
        public string Value { get; }
        public Cards(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString() => $"{Value} of {Suit}";

    }
}
