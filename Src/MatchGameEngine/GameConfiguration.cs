using MatchGameEngine.MatchRules;
using MatchGameEngine.Models;

namespace MatchGameEngine
{
    public class GameConfiguration
    {
        public Player PlayerA { get; }
        public Player PlayerB { get; }
        public int DecksCount { get; }
        public IMatchRule MatchRule { get; }

        public GameConfiguration(Player playerA, Player playerB, int decksCount, IMatchRule matchRule)
        {
            PlayerA = playerA;
            PlayerB = playerB;
            DecksCount = decksCount;
            MatchRule = matchRule;
        }
    }
}