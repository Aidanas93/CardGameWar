using CardGameWar.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace CardGameWar.Models
{
    public class Player
    {
        public List<Card> Hand { get; set; }
        public List<Card> ScorePile { get; private set; } = new List<Card>();

        public Card TakeCurrentCard()
        {
            Card card = Hand.FirstOrDefault();

            if (Hand.Any())
                Hand.RemoveAt(0);           

            return card;
        }
    }
}
