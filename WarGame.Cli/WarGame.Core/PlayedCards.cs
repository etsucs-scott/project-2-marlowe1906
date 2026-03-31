using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame.Core
{
    public class PlayedCards
    {
        // The pot accumulates cards across tied rounds until someone wins it
        public List<Cards> Pot = new List<Cards>();
        public Dictionary<string, Cards> Collect(Dictionary<string, Hand> allHands)
        {
            var played = new Dictionary<string, Cards>();

            // Generalized loop instead of if/else per player count
            foreach (var (playerName, hand) in allHands)
            {
                if (hand.CanPlay())
                {
                    Cards card = hand.Play();
                    played[playerName] = card;

                    // All played cards go into the pot immediately
                    Pot.Add(card);
                }
            }

            return played;
        }

        public void AwardPot(string winner, Dictionary<string, Hand> allHands)
        {
            foreach (var card in Pot)
                allHands[winner].AddCard(card);

            Pot.Clear();
        }
    }
}