namespace WarGame.Core
{
    public class PlayerHands
    {
        public Dictionary<string, Hand> AllHands = new Dictionary<string, Hand>();

        public Dictionary<string, Hand> PlayerHand(int players, List<string> names)
        {
            Deck deck = new Deck();
            List<Cards> cards = new List<Cards>(deck.cards);

            Stack<Cards> shuffled = new Stack<Cards>(deck.Shuffle(cards));

            // Initialize a Hand for each player
            for (int i = 0; i < players; i++)
                AllHands.Add(names[i], new Hand());

            // Round-robin deal
            int index = 0;
            while (shuffled.Count > 0)
            {
                Cards card = shuffled.Pop();
                AllHands[names[index % players]].AddCard(card);  
                index++;
            }

            return AllHands;
        }
    }
}