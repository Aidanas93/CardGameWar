using CardGameWar.Enums;
using CardGameWar.Extensions;
using CardGameWar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameWar.CardGames
{
    public class WarGame
    {
        public Player PlayerOne { get; private set; } = new Player();
        public Player PlayerTwo { get; private set; } = new Player();
        public Deck Deck { get; private set; } = new Deck();
        public Suit TrumpSuit { get; private set; }
        public WarGame()
        {
            SetTrumpCard();

            Deck.Initialize();
            Deck.Shuffle();
            Deck.Deal(PlayerOne, PlayerTwo);
            Play();
        }

        private void SetTrumpCard()
        {
            Random rng = new Random();
            int number = rng.Next(0, 4);
            TrumpSuit = (Suit)number;
        }

        private void Play()
        {
            while(PlayerOne.Hand.Any() && PlayerTwo.Hand.Any())
            {
                bool playerOneHaveTrump = PlayerOne.IsTrumpSuit(TrumpSuit);
                bool playerTwoHaveTrump = PlayerTwo.IsTrumpSuit(TrumpSuit);

                Card plyerOneCurrentCard = PlayerOne.GetCurrentCard();
                Card plyerTwoCurrentCard = PlayerOne.GetCurrentCard();

                if ((playerOneHaveTrump && playerTwoHaveTrump) || (!playerOneHaveTrump && !playerTwoHaveTrump))
                {                    
                    if (plyerOneCurrentCard.Face == plyerTwoCurrentCard.Face)
                    {
                        AddScoreToPlayers();
                    }
                    else if (plyerOneCurrentCard.Face < plyerTwoCurrentCard.Face)
                    {
                        AddScoreToPlayer(plyerOneCurrentCard, plyerTwoCurrentCard, PlayerTwo);
                    }
                    else
                    {
                        AddScoreToPlayer(plyerOneCurrentCard, plyerTwoCurrentCard, PlayerOne);
                    }
                }
                else if(playerOneHaveTrump && !playerTwoHaveTrump)
                {
                    AddScoreToPlayer(plyerOneCurrentCard, plyerTwoCurrentCard, PlayerOne);
                }
                else
                {
                    AddScoreToPlayer(plyerOneCurrentCard, plyerTwoCurrentCard, PlayerTwo);
                }

                PlayerOne.Hand.Remove(plyerOneCurrentCard);
                PlayerTwo.Hand.Remove(plyerTwoCurrentCard);
            }
        }
        private void AddScoreToPlayers()
        {
            PlayerOne.ScorePile.Add(PlayerOne.GetCurrentCard());
            PlayerTwo.ScorePile.Add(PlayerTwo.GetCurrentCard());
        }

        private void AddScoreToPlayer(Card plyerOneCurrentCard, Card plyerTwoCurrentCard, Player player)
        {
            player.ScorePile.Add(plyerOneCurrentCard);
            player.ScorePile.Add(plyerTwoCurrentCard);
        }
    }
}
