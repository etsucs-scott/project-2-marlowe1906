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
        public Deck()
        {
            var list = new List<Cards>();

            foreach (var suit in Cards.Suits)
                foreach (var rank in Cards.Values)
                    list.Add(new Cards(rank, suit));

            cards = new Stack<Cards>(list);
        }

        public Cards Deal()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("Deck is empty.");
            return cards.Pop();
        }

        public int Count => cards.Count;
        public bool IsEmpty =>  cards.Count == 0;

        private void Shuffle(List<Cards> cards)
        {
            var rng = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        /*
        public Stack<string> deck = new Stack<string>();

        public void OrderedDeck()
        {
            int PlaceHolder = 0;
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Push(card.values[PlaceHolder]);
                }
                PlaceHolder++;
            }
            
        }
        public Stack<string> ShuffledDeck()
        {
            Random random = new Random();

            List<int> Completed = new List<int>();
            Stack<string> ShuffledDeck = new Stack<string>();
            
            int PlaceHolder = 0;

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Push(card.values[PlaceHolder]);
                }
                PlaceHolder++;
            }

            while (ShuffledDeck.Count < 52)
            {
                int Value = random.Next(0, 52);

                if (!Completed.Contains(Value))
                {
                    ShuffledDeck.Push(deck.ElementAt(Value));
                    Completed.Add(Value);
                }
            }

            return ShuffledDeck;
        }
        public string Pop(Stack<string> deck)
        {
            return deck.Pop();
        }
        */

    }
}
