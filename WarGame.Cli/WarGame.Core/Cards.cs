namespace WarGame.Core
{
    public class Cards
    {
        // Card values
        public static readonly string[] Values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        public static readonly string[] Suits = new string[] { "Hearts", "Diamonds", "Spades", "Clubs" };

        public string Suit { get; }
        public string Value { get; }

        // Creates a new card with the given value and suit

        public Cards(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }

        // Returns a readable string example: "K of Hearts"
        public override string ToString() => $"{Value} of {Suit}";

    }
}
