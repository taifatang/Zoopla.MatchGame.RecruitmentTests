using MatchGameEngine.Models;

namespace MatchGameEngine.MatchRules
{
    public interface IMatchRule
    {
        bool Match(Card cardA, Card cardB);
    }
}
