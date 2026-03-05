using System.Runtime.CompilerServices;
using WarGame.Core;

Deck deck = new Deck();

foreach (string value in deck.ShuffledDeck())
{
    Console.WriteLine(value);
}