using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WarGame.Core
{
    public class Deck
    {
        Cards card = new Cards();

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

    }
}
