using MatchGameEngine.Models;
using System;
using System.Collections.Generic;

namespace MatchGameEngine
{
    public class Game
    {
        private IDeckProvider deckProvider;

        public Game(IDeckProvider deckProvider)
        {
            this.deckProvider = deckProvider;
        }

        public Player Play(Player[] players)
        {
            var cards = deckProvider.GetCards(1);

            foreach(var card in cards)
            {
                var random = new Random();

                if (random.Next(0, 10) % 2 == 0)
                {
                    players[0].Win(new [] { card });
                }
                else
                {
                    players[1].Win(new [] { card });
                }
            }

            return players[0].Cards.Count > players[1].Cards.Count ? players[0] : players[1];
        }

    }
}
