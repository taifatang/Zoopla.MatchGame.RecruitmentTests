using MatchGameEngine.Models;
using System;
using System.Collections.Generic;

namespace MatchGameEngine
{
    public class Game
    {
        private readonly IDeckProvider _deckProvider;
        private readonly GameConfiguration configuration;

        private LinkedList<Card> _cardsPlayed;

        public Game(IDeckProvider deckProvider, GameConfiguration configuration)
        {
            _deckProvider = deckProvider;
            this.configuration = configuration;
            _cardsPlayed = new LinkedList<Card>();
        }

        public GameResult Play()
        {
            var cards = _deckProvider.GetCards(configuration.DecksCount);

            foreach (var card in cards)
            {
                _cardsPlayed.AddLast(new LinkedListNode<Card>(card));

                if (configuration.MatchRule.Match(_cardsPlayed.Last.Value, card))
                {
                    RandomlyAssignWinner();
                    _cardsPlayed.Clear();
                }
            }

            if (configuration.PlayerA.Cards.Count == configuration.PlayerB.Cards.Count)
            {
                return GameResult.Draw();
            }

            var winner = configuration.PlayerA.Cards.Count > configuration.PlayerB.Cards.Count
                ? configuration.PlayerA
                : configuration.PlayerB;

            return GameResult.Victory(winner);
        }

        private void RandomlyAssignWinner()
        {
            var random = new Random();

            if (random.Next(0, 10) % 2 == 0)
            {
                configuration.PlayerA.Win(_cardsPlayed);
            }
            else
            {
                configuration.PlayerB.Win(_cardsPlayed);
            }
        }
    }
}
