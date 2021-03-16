using System;
using System.Collections.Generic;

namespace CardGameWar.Models
{
    public abstract class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        public void Initialize(int startFaceIndex, int endFaceIndex)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = startFaceIndex; j <= endFaceIndex; j++)
                {
                    Cards.Add(new Card((Suit)i, (Face)j));
                }
            }
        }

        public abstract void Deal(List<Player> players);

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
        }        
    }
}
