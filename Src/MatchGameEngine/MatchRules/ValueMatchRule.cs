using MatchGameEngine.Models;

namespace MatchGameEngine.MatchRules
{
    public class ValueMatchRule : IMatchRule
    {
        public bool Match(Card cardA, Card cardB)
        {
            return cardA.Value == cardB.Value;
        }
    }
}
