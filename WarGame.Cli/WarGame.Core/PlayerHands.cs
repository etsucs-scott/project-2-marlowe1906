using System;
using System.Collections.Generic;
namespace WarGame.Core
{
    public class PlayerHands
    {
        public Dictionary<string, Queue<string>> AllHands = new Dictionary<string, Queue<string>>();
        /*
        public Dictionary<string, Queue<string>> PlayerHand(int Players, List<string> names)
        {
            Deck Deck = new Deck();
            Hand Hand = new Hand();
            Stack<string> deck = Deck.ShuffledDeck();

            // Deal once and grab the result
            var dealt = Hand.PlayerHands(Players, deck);

            if (Players >= 2)
            {
                AllHands.Add(names[0], dealt.Player1);
                AllHands.Add(names[1], dealt.Player2);
            }

            if (Players >= 3)
                AllHands.Add(names[2], dealt.Player3);

            if (Players >= 4)
                AllHands.Add(names[3], dealt.Player4);

            if (Players < 2 || Players > 4)
                Console.WriteLine("Please enter a valid amount of players");

            return AllHands;
        }
        */
    }
}