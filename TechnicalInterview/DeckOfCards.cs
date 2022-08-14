namespace TechnicalInterview
{
    public class DeckOfCards : Deck<Card>
    {
        public IEnumerable<Card> Deck { get; set; }
        

        public DeckOfCards()
        {
            Deck = Utilities.GenerateDeck();
        }

        public void Shuffle()
        {
            //Using Fisher-Yates Algorithm (https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle)

            //"Random" seed so shuffles are more realistic
            var shuffler = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < Deck.Count(); i++)
            {
                var j = shuffler.Next(i, Deck.Count());

                Swap(i, j);
            }
        }

        public void Sort()
        {
            Deck = Deck.OrderBy(x => x.suit).ThenBy(x => x.details.faceValue); 
        }

        public void Sort(SortOrdinals sort)
        {
            if(sort == SortOrdinals.SUIT)
            {
                Deck = Deck.OrderBy(x => x.suit).ThenBy(x => x.details.faceValue);
            }
            else if (sort == SortOrdinals.VALUE)
            {
                Deck = Deck.OrderBy(x => x.details.numericalValue).ThenBy(x => x.details.faceValue);
            }
        }

        public void Swap (int indexOne, int indexTwo)
        {
            var malleableDeck = Deck.ToArray();

            var original = malleableDeck[indexOne];
            var replacer = malleableDeck[indexTwo];

            if(original != null && replacer != null)
            {
                malleableDeck[indexOne] = replacer;
                malleableDeck[indexTwo] = original;
            }

            Deck = malleableDeck.AsEnumerable();
            
        }

       
    }
}

