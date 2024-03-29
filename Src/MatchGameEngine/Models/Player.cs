﻿using System.Collections.Generic;

namespace MatchGameEngine.Models
{
    public class Player
    {
        public string Name { get; }
        public IReadOnlyList<Card> Cards => _cards;
        private readonly List<Card> _cards;

        public Player(string name)
        {
            Name = name;
            _cards = new List<Card>();
        }
        //A bit Domain driven here to prevent player adding cards to themselves
        public void Win(IEnumerable<Card> cards)
        {
            _cards.AddRange(cards);
        }
    }
}
