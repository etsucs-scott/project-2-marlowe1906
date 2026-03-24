using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame.Core
{
    public class PlayedCards
    {
        public Dictionary<int, string> Collect(int Players, Dictionary<string, Queue<string>> AllHands, int round, List<string> names, Dictionary<int, string> Played)
        {
            if (Players == 2)
            {
                AllHands.TryGetValue(names[0], out Queue<string> P1cards);
                AllHands.TryGetValue(names[1], out Queue<string> P2cards);

                Played.Add(round, P1cards.Dequeue() + "," + P2cards.Dequeue());
            }
            else if (Players == 3)
            {
                AllHands.TryGetValue(names[0], out Queue<string> P1cards);
                AllHands.TryGetValue(names[1], out Queue<string> P2cards);
                AllHands.TryGetValue(names[2], out Queue<string> P3cards);

                Played.Add(round, P1cards.Dequeue() + "," + P2cards.Dequeue() + "," + P3cards.Dequeue());
            }
            else if (Players == 4)
            {
                AllHands.TryGetValue(names[0], out Queue<string> P1cards);
                AllHands.TryGetValue(names[1], out Queue<string> P2cards);
                AllHands.TryGetValue(names[2], out Queue<string> P3cards);
                AllHands.TryGetValue(names[3], out Queue<string> P4cards);

                Played.Add(round, P1cards.Dequeue() + "," + P2cards.Dequeue() + "," + P3cards.Dequeue() + "," + P4cards.Dequeue());
            }
            else
            {
                Console.WriteLine("Please use a valid amount of players");
            }

            return Played;
        }
    }
}
