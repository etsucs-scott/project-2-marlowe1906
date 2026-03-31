using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WarGame.Core
{
    public class Deck
    {
        public Stack<Cards> cards;

        // Builds the full 52-card deck by combining all suits and values
        public Deck()
        {
            var list = new List<Cards>();

            foreach (var suit in Cards.Suits)
                foreach (var rank in Cards.Values)
                    list.Add(new Cards(rank, suit));

            cards = new Stack<Cards>(list);
        }

        // Removes and returns the top card, throws if deck is empty
        public Cards Deal()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("Deck is empty.");
            return cards.Pop();
        }

        public int Count => cards.Count;
        public bool IsEmpty => cards.Count == 0;

        // Randomly reorders the card list in place
        public List<Cards> Shuffle(List<Cards> cards)
        {

            var rng = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }

            return cards;
        }
    }
}