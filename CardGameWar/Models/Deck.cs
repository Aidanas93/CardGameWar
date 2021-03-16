using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameWar.Models
{
    public class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();
        private bool isShuffled = false;
        public void Initialize()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j <= 14; j++)
                {
                    Cards.Add(new Card((Suit)i, (Face)j));
                }
            }
        }

        public void Deal(Player playerOne, Player playerTwo)
        {
            if (!isShuffled)
                throw new Exception("Deck was not shuffled.");

            if(Cards.Count % 2 == 0)
            {
                int cardsToTake = Cards.Count / 2;
                playerOne.Hand = Cards.Take(cardsToTake).ToList();
                playerTwo.Hand = Cards.Skip(cardsToTake).Take(cardsToTake).ToList();
            }
            else
            {
                throw new Exception("Invalid card count.");
            }
        }

        public void Shuffle()
        {
            int n = Cards.Count;
            Random rng = new Random();
            while(n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }

            isShuffled = true;
        }        
    }
}
