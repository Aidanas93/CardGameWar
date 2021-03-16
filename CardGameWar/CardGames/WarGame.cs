using CardGameWar.Enums;
using CardGameWar.Extensions;
using CardGameWar.Models;
using System;
using System.Collections.Generic;

namespace CardGameWar.CardGames
{
    public class WarGame
    {
        public List<Player> Players { get; private set; } = new List<Player>() 
        {
            new Player(),
            new Player(),
        };
        public Deck Deck { get; private set; } = new Deck();
        public Suit TrumpSuit { get; set; }
        public WarGame()
        {
            SetTrumpCard();

            Deck.Initialize();
            Deck.Shuffle();
            Deck.Deal(Players);
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
            PlayerTurn currentPlayer = PlayerTurn.First;
            PlayerTurn opponentPlayer = PlayerTurn.Second;

            while(Players[0].Hand.Count != 0)
            {
                bool currentHaveTrump = Players[currentPlayer.Value()].IsTrumpSuit(TrumpSuit);
                bool opponentTwoHaveTrump = Players[opponentPlayer.Value()].IsTrumpSuit(TrumpSuit);

                if ((currentHaveTrump && opponentTwoHaveTrump) || (!currentHaveTrump && !opponentTwoHaveTrump))
                {
                    if (Players[currentPlayer.Value()].Hand[0].Face == Players[opponentPlayer.Value()].Hand[0].Face)
                    {
                        TieRound(currentPlayer.Value(), opponentPlayer.Value());
                    }
                    else if (Players[currentPlayer.Value()].Hand[0].Face < Players[opponentPlayer.Value()].Hand[0].Face)
                    {
                        OpponentPlayerWonRound(currentPlayer.Value(), opponentPlayer.Value());
                    }
                    else
                    {
                        CurrentPlayerWonRound(currentPlayer.Value(), opponentPlayer.Value());
                    }
                }
                else if(currentHaveTrump && !opponentTwoHaveTrump)
                {
                    CurrentPlayerWonRound(currentPlayer.Value(), opponentPlayer.Value());
                }
                else
                {
                    OpponentPlayerWonRound(currentPlayer.Value(), opponentPlayer.Value());
                }                

                Players[currentPlayer.Value()].Hand.RemoveAt(0);
                Players[opponentPlayer.Value()].Hand.RemoveAt(0);

                PlayerTurn playerToRemember = currentPlayer;
                currentPlayer = opponentPlayer;
                opponentPlayer = playerToRemember;
            }
        }
        private void CurrentPlayerWonRound(int currentPlayer, int opponentPlayer)
        {
            Players[currentPlayer].ScorePile.Add(Players[currentPlayer].Hand[0]);
            Players[currentPlayer].ScorePile.Add(Players[opponentPlayer].Hand[0]);
        }

        private void OpponentPlayerWonRound(int currentPlayer, int opponentPlayer)
        {
            Players[opponentPlayer].ScorePile.Add(Players[currentPlayer].Hand[0]);
            Players[opponentPlayer].ScorePile.Add(Players[opponentPlayer].Hand[0]);
        }

        private void TieRound(int currentPlayer, int opponentPlayer)
        {
            Players[currentPlayer].ScorePile.Add(Players[currentPlayer].Hand[0]);
            Players[opponentPlayer].ScorePile.Add(Players[opponentPlayer].Hand[0]);
        }
    }
}
