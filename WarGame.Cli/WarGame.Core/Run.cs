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
            PlayedCards cards = new PlayedCards();
            List<string> names = new List<string>();

            Console.Write("How many players do you want to run (2,3,4)? ");
            int players = int.Parse(Console.ReadLine());

            for (int j = 0; j < players; j++)
            {
                Console.Write("What is the name of player " + (j + 1) + "? ");
                names.Add(Console.ReadLine());
            }

            Dictionary<string, Queue<string>> AllHands = hands.PlayerHand(players, names);
            Dictionary<int, string> Played = new Dictionary<int, string>();
            HashSet<string> seenStates = new HashSet<string>();

            int i = 0;
            int rounds = 1;

            while (AllHands.Values.All(q => q.Count > 0) && rounds < 10000)
            {
                // Detect infinite loop
                string state = string.Join("|", names.Select(n => string.Join(",", AllHands[n])));
                if (seenStates.Contains(state))
                {
                    Console.WriteLine("Game has entered an infinite loop — declaring a draw!");
                    return;
                }
                seenStates.Add(state);

                Console.WriteLine("\n--- Round " + rounds + " ---");
                foreach (string name in names)
                    Console.WriteLine(name + " has " + AllHands[name].Count + " cards");

                cards.Collect(players, AllHands, i, names, Played);

                string[] InPlay = Played[i].Split(",");

                // Convert and display played cards
                int[] cardValues = new int[players];
                for (int p = 0; p < players; p++)
                {
                    cardValues[p] = ConvertCard(InPlay[p]);
                    Console.WriteLine(names[p] + " played: " + InPlay[p]);
                }

                // Find the winner(s)
                int maxValue = cardValues.Max();
                List<int> winners = new List<int>();
                for (int p = 0; p < players; p++)
                {
                    if (cardValues[p] == maxValue)
                        winners.Add(p);
                }

                if (winners.Count == 1)
                {
                    int winnerIndex = winners[0];
                    Console.WriteLine(names[winnerIndex] + " wins this round!");

                    // Winner gets all played cards
                    foreach (string card in InPlay)
                        AllHands[names[winnerIndex]].Enqueue(card);
                }
                else
                {
                    // Tie — tied players get their card back, others lose theirs
                    Console.WriteLine("Tie between: " + string.Join(", ", winners.Select(w => names[w])));
                    foreach (int w in winners)
                        AllHands[names[w]].Enqueue(InPlay[w]);
                }

                // Eliminate players with no cards
                List<string> eliminated = names.Where(n => AllHands[n].Count == 0).ToList();
                foreach (string name in eliminated)
                {
                    Console.WriteLine(name + " has been eliminated!");
                    names.Remove(name);
                    AllHands.Remove(name);
                    players--;
                }

                // Check if only one player remains
                if (names.Count == 1)
                {
                    Console.WriteLine("\n" + names[0] + " wins the game!");
                    return;
                }

                rounds++;
                i++;
            }

            // Fallback — shouldn't normally reach here
            string winner = AllHands.OrderByDescending(kv => kv.Value.Count).First().Key;
            Console.WriteLine("\n" + winner + " wins the game with " + AllHands[winner].Count + " cards!");
        }

        private int ConvertCard(string card)
        {
            return card switch
            {
                "J" => 11,  
                "Q" => 12,
                "K" => 13,
                "A" => 14,
                _ => int.Parse(card)
            };
        }
    }
}