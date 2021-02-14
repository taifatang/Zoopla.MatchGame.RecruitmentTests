﻿namespace MatchGameEngine.Models
{
    public class Card
    {
        public Suit Suit { get;  }
        public CardValue Value { get;  }

        public Card(Suit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
