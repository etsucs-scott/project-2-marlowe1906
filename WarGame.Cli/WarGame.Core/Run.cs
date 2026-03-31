using System;
using System.Collections.Generic;
using System.Linq;

namespace WarGame.Core
{
    public class Run
    {
        public void Execute()
        {
            PlayerHands hands = new PlayerHands();
            PlayedCards playedCards = new PlayedCards();
            List<string> names = new List<string>();

            Console.Write("How many players do you want to run (2,3,4)? ");
            int players = int.Parse(Console.ReadLine());

            for (int j = 0; j < players; j++)
            {
                Console.Write("What is the name of player " + (j + 1) + "? ");
                names.Add(Console.ReadLine());
            }

            Dictionary<string, Hand> allHands = hands.PlayerHand(players, names);

            int rounds = 1;

            while (rounds <= 10000)
            {
                // Eliminate players with no cards before each round
                List<string> eliminated = names.Where(n => allHands[n].IsEmpty).ToList();
                foreach (string name in eliminated)
                {
                    Console.WriteLine(name + " has been eliminated!");
                    names.Remove(name);
                    allHands.Remove(name);
                }

                if (names.Count == 1)
                {
                    Console.WriteLine("\n" + names[0] + " wins the game!");
                    return;
                }

                Console.WriteLine("\n--- Round " + rounds + " ---");
                foreach (string name in names)
                    Console.WriteLine(name + " has " + allHands[name].Count + " cards");

                // Play a round (handles ties recursively with shared pot)
                string winner = PlayRound(names, allHands, playedCards);

                if (winner != null)
                    Console.WriteLine(winner + " wins the round and collects the pot!");

                rounds++;
            }

            // Round cap reached — player with most cards wins
            string gameWinner = allHands.OrderByDescending(kv => kv.Value.Count).First().Key;
            int topCount = allHands[gameWinner].Count;
            var leaders = allHands.Where(kv => kv.Value.Count == topCount).Select(kv => kv.Key).ToList();

            if (leaders.Count == 1)
                Console.WriteLine("\n" + gameWinner + " wins with " + topCount + " cards!");
            else
                Console.WriteLine("\nDraw! Leaders: " + string.Join(", ", leaders));
        }

        private string PlayRound(List<string> names, Dictionary<string, Hand> allHands, PlayedCards playedCards)
        {
            Dictionary<string, Cards> played = playedCards.Collect(allHands);

            // Print what each player played
            foreach (var (name, card) in played)
                Console.WriteLine(name + " played: " + card);

            // Find the highest rank among played cards
            var highRank = played.Values.Max(c => c.Value);
            List<string> winners = played.Where(kv => kv.Value.Value == highRank)
                                         .Select(kv => kv.Key)
                                         .ToList();

            if (winners.Count == 1)
            {
                // Clear winner — award entire pot to them
                playedCards.AwardPot(winners[0], allHands);
                return winners[0];
            }

            // Tie — pot stays, only tied players continue into tiebreaker
            Console.WriteLine("Tie between: " + string.Join(", ", winners));
            Console.WriteLine("Pot has " + playedCards.Pot.Count + " cards — playing tiebreaker!");

            // Eliminate tied players who have no cards left for the tiebreaker
            List<string> canPlay = winners.Where(n => allHands[n].CanPlay()).ToList();
            List<string> cannotPlay = winners.Except(canPlay).ToList();
            foreach (string name in cannotPlay)
            {
                Console.WriteLine(name + " cannot play a tiebreaker and is eliminated!");
                names.Remove(name);
                allHands.Remove(name);
            }

            if (canPlay.Count == 1)
            {
                // Only one tied player left — they win the pot
                playedCards.AwardPot(canPlay[0], allHands);
                return canPlay[0];
            }

            if (canPlay.Count > 1)
            {
                // Recurse — tiebreaker round among only the tied players
                return PlayRound(canPlay, allHands, playedCards);
            }

            // Everyone eliminated during tie — pot is abandoned
            return null;
        }
    }
}