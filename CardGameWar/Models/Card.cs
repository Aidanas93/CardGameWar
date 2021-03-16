namespace CardGameWar.Models
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public Face Face { get; private set; }
        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
        }
    }
}
