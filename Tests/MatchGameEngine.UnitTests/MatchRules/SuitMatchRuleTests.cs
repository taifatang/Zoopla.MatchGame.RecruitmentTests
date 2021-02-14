using FluentAssertions;
using MatchGameEngine.MatchRules;
using MatchGameEngine.Models;
using NUnit.Framework;

namespace MatchGameEngine.UnitTests.MatchRules
{
    [TestFixture]
    public class SuitMatchRuleTests
    {
        [Test]
        public void SuitMatchRule_MatchSameSuit_ReturnsTrue()
        {
            var rule = new SuitMatchRule();

            var result = rule.Match(new Card(Suit.Clubs, CardValue.Ace), new Card(Suit.Clubs, CardValue.Eight));

            result.Should().BeTrue();
        }

        [Test]
        public void SuitMatchRule_MatchDifferentSuit_ReturnsFalse()
        {
            var rule = new SuitMatchRule();

            var result = rule.Match(new Card(Suit.Clubs, CardValue.Ace), new Card(Suit.Diamonds, CardValue.Ace));

            result.Should().BeFalse();
        }
    }
}
