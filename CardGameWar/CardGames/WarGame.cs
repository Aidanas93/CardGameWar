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
            if(Deck.Cards.Count % 2 == 0)
            {
                while (PlayerOne.Hand.Any() && PlayerTwo.Hand.Any())
                {
                    Card plyerOneCurrentCard = PlayerOne.TakeCurrentCard();
                    Card plyerTwoCurrentCard = PlayerOne.TakeCurrentCard();
                    GameResult result = (GameResult)Math.Sign(plyerOneCurrentCard.GetCardValue(TrumpSuit).CompareTo(plyerTwoCurrentCard.GetCardValue(TrumpSuit)));

                    switch (result)
                    {
                        case GameResult.PlayerOneWon:
                            PlayerOne.ScorePile.Add(plyerOneCurrentCard);
                            PlayerOne.ScorePile.Add(plyerTwoCurrentCard);
                            break;
                        case GameResult.PlayerTwoWon:
                            PlayerTwo.ScorePile.Add(plyerOneCurrentCard);
                            PlayerTwo.ScorePile.Add(plyerTwoCurrentCard);
                            break;
                        default:
                            PlayerOne.ScorePile.Add(plyerOneCurrentCard);
                            PlayerTwo.ScorePile.Add(plyerTwoCurrentCard);
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("Invalid card count.");
            }
        }
    }
}
