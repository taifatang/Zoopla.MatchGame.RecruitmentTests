using MatchGameEngine.Models;

namespace MatchGameEngine.MatchRules
{
    public class ValueAndSuitMatchRule : IMatchRule
    {
        public bool Match(Card cardA, Card cardB)
        {
            return cardA.Suit == cardB.Suit 
                && cardA.Value == cardB.Value;
        }
    }
}
