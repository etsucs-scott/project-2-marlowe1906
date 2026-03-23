using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame.Core
{
    public class PlayerHands
    {
        public Dictionary<string, Queue<string>> AllHands = new Dictionary<string, Queue<string>>();
        public Dictionary<string, Queue<string>> PlayerHand(int Players, List<string> names)
        {
            Deck Deck = new Deck();
            Hand Hand = new Hand();

            Stack<string> deck = new Stack<string>();
            deck = Deck.ShuffledDeck();

           if (Players == 2)
            {
                AllHands.Add(names[0], Hand.PlayerHands(Players, deck).Player1);
                AllHands.Add(names[1], Hand.PlayerHands(Players, deck).Player2);
            }
           else if (Players == 3)
            {
                AllHands.Add(names[0], Hand.PlayerHands(Players, deck).Player1);
                AllHands.Add(names[1], Hand.PlayerHands(Players, deck).Player2);
                AllHands.Add(names[2], Hand.PlayerHands(Players, deck).Player3);
            }
            else if (Players == 4)
            {
                AllHands.Add(names[0], Hand.PlayerHands(Players, deck).Player1);
                AllHands.Add(names[1], Hand.PlayerHands(Players, deck).Player2);
                AllHands.Add(names[2], Hand.PlayerHands(Players, deck).Player3);
                AllHands.Add(names[3], Hand.PlayerHands(Players, deck).Player4);
            }
            else
            {
                Console.WriteLine("Please enter a valid amount of players");
            }

            return AllHands;
        }
    }
}
