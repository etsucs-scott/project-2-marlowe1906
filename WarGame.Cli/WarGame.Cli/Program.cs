using System.Runtime.CompilerServices;
using WarGame.Core;

Run run = new Run();
Deck deck = new Deck();

foreach (var card in deck.cards)
{
    Console.WriteLine(deck.Deal());
}



