using System;
namespace TechnicalInterview
{
    public static class Utilities
    {
        public static IEnumerable<Card> GenerateDeck()
        {
            var deck = new List<Card>();

            foreach(var suit in Enumerable.Range(0,3))
            {
                foreach(var card in Enumerable.Range(0,12))
                {
                    var value = (card < 10) ? card+1 : 10;

                    deck.Add(new Card((Suit)suit, (CardFaces)card, value));
                }
            }

            return deck.AsEnumerable();
        }
    }
}

