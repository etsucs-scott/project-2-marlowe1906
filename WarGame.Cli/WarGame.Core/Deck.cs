using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame.Core
{
    public class Deck
    {
        Cards card = new Cards();
        public Stack<string> deck = new Stack<string>();

        public void Generate()
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
            foreach (string values in deck)
            {
                Console.WriteLine(values);
            }
        }

    }
}
