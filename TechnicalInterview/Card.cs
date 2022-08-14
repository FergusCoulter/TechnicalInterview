namespace TechnicalInterview
{
    public class Card
    {
        public Suit suit { get; set; }
        public CardDetails details { get; set; }

        public Card(Suit suit, CardFaces face, int cardValue)
        {
            details = new CardDetails(cardValue, face);
            this.suit = suit;
            
        }

        public override string ToString() => $"{details.faceValue} of {suit}";
        

    }
}

