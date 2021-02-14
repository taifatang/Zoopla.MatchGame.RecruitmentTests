using System.Collections.Generic;

namespace MatchGameEngine.Models
{
    public class Player
    {
        public IReadOnlyList<Card> Cards => _cards;
        private readonly List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>();
        }
        public void Win(IEnumerable<Card> cards)
        {
            _cards.AddRange(cards);
        }
    }
}
