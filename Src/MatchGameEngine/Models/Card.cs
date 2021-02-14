namespace MatchGameEngine.Models
{
    public struct Card
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
