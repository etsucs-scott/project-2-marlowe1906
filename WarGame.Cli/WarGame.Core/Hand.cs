using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace WarGame.Core
{
    public class Hand
    {
        

        public Queue<string> Player1 = new Queue<string>();
        public Queue<string> Player2 = new Queue<string>();
        public Queue<string> Player3 = new Queue<string>();
        public Queue<string> Player4 = new Queue<string>();

        public (Queue<string> Player1, Queue<string> Player2, Queue<string> Player3, Queue<string> Player4) PlayerHands(int Players, Stack<string> deck)
        {
            int PlaceHolder = 0;
            while (deck.Count > 0)
            {
                if (Players == 2)
                {
                    if (PlaceHolder == 0 && deck.Count > 0)
                    {
                        Player1.Enqueue(deck.Pop());
                        PlaceHolder = 1;
                    }
                    else if (PlaceHolder == 1 && deck.Count > 0)
                    {
                        Player2.Enqueue(deck.Pop());
                        PlaceHolder = 0;
                    }
                }
                else if (Players == 3)
                {
                    if (PlaceHolder == 0 && deck.Count > 0)
                    {
                        Player1.Enqueue(deck.Pop());
                        PlaceHolder = 1;
                    }
                    else if (PlaceHolder == 1 && deck.Count > 0)
                    {
                        Player2.Enqueue(deck.Pop());
                        PlaceHolder = 2;
                    }
                    else if (PlaceHolder == 2 && deck.Count > 0)
                    {
                        Player3.Enqueue(deck.Pop());
                        PlaceHolder = 0;
                    }
                }
                else if (Players == 4)
                {
                    if (PlaceHolder == 0 && deck.Count > 0)
                    {
                        Player1.Enqueue(deck.Pop());
                        PlaceHolder = 1;
                    }
                    else if (PlaceHolder == 1 && deck.Count > 0)
                    {
                        Player2.Enqueue(deck.Pop());
                        PlaceHolder = 2;
                    }
                    else if (PlaceHolder == 2 && deck.Count > 0)
                    {
                        Player3.Enqueue(deck.Pop());
                        PlaceHolder = 3;
                    }
                    else if (PlaceHolder == 3 && deck.Count > 0)
                    {
                        Player4.Enqueue(deck.Pop());
                        PlaceHolder = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Please input a valid amount of players");
                }
            }
            

            return (Player1, Player2, Player3, Player4);
        }

    }
}
