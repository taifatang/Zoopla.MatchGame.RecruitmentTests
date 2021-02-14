using MatchGameEngine.Models;
using System;
using System.Collections.Generic;

namespace MatchGameEngine
{
    public class Game
    {
        private readonly IDeckProvider _deckProvider;
        private readonly GameConfiguration _configuration;

        private LinkedList<Card> _cardsPlayed;

        public Game(IDeckProvider deckProvider, GameConfiguration configuration)
        {
            _deckProvider = deckProvider;
            _configuration = configuration;
            _cardsPlayed = new LinkedList<Card>();
        }

        public GameResult Play()
        {
            var cards = _deckProvider.GetCards(_configuration.DecksCount);

            foreach (var card in cards)
            {
                _cardsPlayed.AddLast(new LinkedListNode<Card>(card));

                if (_configuration.MatchRule.Match(_cardsPlayed.Last.Value, card))
                {
                    RandomlyAssignWinner();
                    _cardsPlayed.Clear();
                }
            }

            if (_configuration.PlayerA.Cards.Count == _configuration.PlayerB.Cards.Count)
            {
                return GameResult.Draw();
            }

            var winner = _configuration.PlayerA.Cards.Count > _configuration.PlayerB.Cards.Count
                ? _configuration.PlayerA
                : _configuration.PlayerB;

            return GameResult.Victory(winner);
        }

        private void RandomlyAssignWinner()
        {
            var random = new Random();

            if (random.Next(0, 10) % 2 == 0)
            {
                _configuration.PlayerA.Win(_cardsPlayed);
            }
            else
            {
                _configuration.PlayerB.Win(_cardsPlayed);
            }
        }
    }
}
