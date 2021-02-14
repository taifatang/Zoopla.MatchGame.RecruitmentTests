using MatchGameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MatchGameEngine
{
    public static class Deck
    {
        public static List<Card> Standard => (from suit in (Suit[])Enum.GetValues(typeof(Suit))
                                             from value in (CardValue[])Enum.GetValues(typeof(CardValue))
                                             select new Card(suit, value)).ToList();
    }
}
