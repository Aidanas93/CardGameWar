using System.Collections.Generic;

namespace CardGameWar.Models
{
    public class Player
    {
        public List<Card> Hand { get; private set; } = new List<Card>();
        public List<Card> ScorePile { get; private set; } = new List<Card>();

        public bool IsTrumpSuit(Suit trumpSuit, Suit playerCard)
            => trumpSuit == playerCard ? true : false;
    }
}
