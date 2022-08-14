
using TechnicalInterview;


var deck = new DeckOfCards();

foreach(var card in deck.Deck)
{
    Console.WriteLine(card.ToString());
}
Console.ReadLine();



deck.Shuffle();
foreach (var card in deck.Deck)
{
    Console.WriteLine(card.ToString());
}
Console.ReadLine();




deck.Sort(SortOrdinals.VALUE);
foreach (var card in deck.Deck)
{
    Console.WriteLine(card.ToString());
}
Console.ReadLine();
