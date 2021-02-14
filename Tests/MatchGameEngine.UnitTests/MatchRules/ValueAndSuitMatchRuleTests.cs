using FluentAssertions;
using MatchGameEngine.MatchRules;
using MatchGameEngine.Models;
using NUnit.Framework;

namespace MatchGameEngine.UnitTests.MatchRules
{
    [TestFixture]
    public class ValueAndSuitMatchRuleTests
    {
        [Test]
        public void ValueAndSuitMatchRule_MatchSameValueAndSuit_ReturnsTrue()
        {
            var rule = new ValueAndSuitMatchRule();

            var result = rule.Match(new Card(Suit.Clubs, CardValue.Ace), new Card(Suit.Clubs, CardValue.Ace));

            result.Should().BeTrue();
        }

        [Test]
        public void ValueAndSuitMatchRule_MatchSameSuitButDifferentValue_ReturnsFalse()
        {
            var rule = new ValueAndSuitMatchRule();

            var result = rule.Match(new Card(Suit.Clubs, CardValue.Ace), new Card(Suit.Clubs, CardValue.Jack));

            result.Should().BeFalse();
        }

        [Test]
        public void ValueAndSuitMatchRule_MatchSameValueButDifferentSuit_ReturnsFalse()
        {
            var rule = new ValueAndSuitMatchRule();

            var result = rule.Match(new Card(Suit.Hearts, CardValue.Ace), new Card(Suit.Clubs, CardValue.Ace));

            result.Should().BeFalse();
        }
    }
}
