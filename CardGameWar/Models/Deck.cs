﻿using CardGameWar.Enums;
using CardGameWar.Extensions;
using System;
using System.Collections.Generic;

namespace CardGameWar.Models
{
    public class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

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

        public void Deal(List<Player> players)
        {
            if (Cards.Count == 0)
                throw new Exception("Deck is not initialized.");

            PlayerTurn currentPlayer = PlayerTurn.First;

            foreach (Card card in Cards)
            {
                players[currentPlayer.Value()].Hand.Add(card);

                if (currentPlayer == PlayerTurn.Second)
                    currentPlayer = PlayerTurn.First;  
                else
                    currentPlayer = PlayerTurn.Second;
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
        }        
    }
}
