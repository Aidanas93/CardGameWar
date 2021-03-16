using CardGameWar.Models;
using System;
using System.Collections.Generic;

namespace CardGameWar.CardGames
{
    public class WarGame
    {
        public List<Player> Players { get; private set; } = new List<Player>();
        public WarGameDeck Deck { get; private set; } = new WarGameDeck();
        public Suit TrumpSuit { get; set; }
        public WarGame(int playerCount)
        {
            SetPlayers(playerCount);
            SetTrumpCard();

            Deck.Initialize(2, 14);
            Deck.Shuffle();
            Deck.Deal(Players);
            Play();
        }

        private void SetPlayers(int playerCount)
        {
            for(int i = 0; i < playerCount; i++)
                Players.Add(new Player());
        }

        private void SetTrumpCard()
        {
            Random rng = new Random();
            int number = rng.Next(0, 4);
            TrumpSuit = (Suit)number;
        }

        private void Play()
        {
            int currentPlayer = 0;
            int opponentPlayer = 1;

            while(Players[0].Hand.Count != 0)
            {
                if (currentPlayer == Players.Count - 1)
                    opponentPlayer = 0;

                bool currentHaveTrump = Players[currentPlayer].IsTrumpSuit(TrumpSuit, Players[currentPlayer].Hand[0].Suit);
                bool opponentTwoHaveTrump = Players[opponentPlayer].IsTrumpSuit(TrumpSuit, Players[opponentPlayer].Hand[0].Suit);

                if ((currentHaveTrump && opponentTwoHaveTrump) || (!currentHaveTrump && !opponentTwoHaveTrump))
                {
                    if (Players[currentPlayer].Hand[0].Face == Players[opponentPlayer].Hand[0].Face)
                    {
                        TieRound(currentPlayer, opponentPlayer);
                    }
                    else if (Players[currentPlayer].Hand[0].Face < Players[opponentPlayer].Hand[0].Face)
                    {
                        OpponentPlayerWonRound(currentPlayer, opponentPlayer);
                    }
                    else
                    {
                        CurrentPlayerWonRound(currentPlayer, opponentPlayer);
                    }
                }
                else if(currentHaveTrump && !opponentTwoHaveTrump)
                {
                    CurrentPlayerWonRound(currentPlayer, opponentPlayer);
                }
                else
                {
                    OpponentPlayerWonRound(currentPlayer, opponentPlayer);
                }                

                Players[currentPlayer].Hand.RemoveAt(0);
                Players[opponentPlayer].Hand.RemoveAt(0);

                currentPlayer = opponentPlayer;
                opponentPlayer++;
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
