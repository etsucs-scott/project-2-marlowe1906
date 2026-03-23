using System.Runtime.CompilerServices;
using WarGame.Core;

PlayerHands hands = new PlayerHands();
PlayedCards cards = new PlayedCards();

List<string> names = new List<string>() {"Eli", "Bella", "Cooper", "Carter"};
Dictionary<string, Queue<string>> AllHands = new Dictionary<string, Queue<string>>();
Dictionary<int, string> Played = new Dictionary<int, string>();

AllHands = hands.PlayerHand(4, names);
cards.Collect(AllHands, 1, names, Played);

Played.TryGetValue(1, out string name);
Console.WriteLine(name);

