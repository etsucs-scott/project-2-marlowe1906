namespace WarGame.Core
{
    public class Hand
    {
        // Required: Queue<Card> to hold the player's cards
        private Queue<Cards> _cards = new Queue<Cards>();

        public int Count => _cards.Count;
        public bool IsEmpty => _cards.Count == 0;

        // Adds a card to the back of the hand (used when receiving won cards).

        public void AddCard(Cards card) => _cards.Enqueue(card);

  
        // Plays the front card from the hand.
        public Cards Play() => _cards.Dequeue();

        // Returns true if the player has at least one card to play.
        public bool CanPlay() => _cards.Count > 0;
    }
}