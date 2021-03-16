using CardGameWar.Extensions;

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

        public int GetCardValue(Suit trumpSuit)
        {
            int cardValue = Face.Value();

            return IsTrumpSuit(trumpSuit) ? cardValue + 100 : cardValue;
        }

        private bool IsTrumpSuit(Suit trumpSuit)
            => trumpSuit == Suit ? true : false;
    }
}
