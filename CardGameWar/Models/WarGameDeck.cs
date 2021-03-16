using System;
using System.Collections.Generic;

namespace CardGameWar.Models
{
    public class WarGameDeck : Deck
    {
        public override void Deal(List<Player> players)
        {
            if (Cards.Count == 0)
                throw new Exception();

            int currentPlayer = 0;
            foreach(Card card in Cards)
            {
                if (currentPlayer == players.Count)
                    currentPlayer = 0;

                players[currentPlayer].Hand.Add(card);

                currentPlayer++;
            }
        }
    }
}
