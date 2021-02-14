using MatchGameEngine.Models;

namespace MatchGameEngine.MatchRules
{
    public class SuitMatchRule : IMatchRule
    {
        public bool Match(Card cardA, Card cardB)
        {
            return cardA.Suit == cardB.Suit;
        }
    }
}
