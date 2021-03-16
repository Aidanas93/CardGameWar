using System.Collections.Generic;
using System.Linq;

namespace CardGameWar.Models
{
    public class Player
    {
        public List<Card> Hand { get; private set; } = new List<Card>();
        public List<Card> ScorePile { get; private set; } = new List<Card>();

        public bool IsTrumpSuit(Suit trumpSuit)
            => trumpSuit == Hand[0].Suit ? true : false;

        public Card GetCurrentCard()
            => Hand.FirstOrDefault();
    }
}
