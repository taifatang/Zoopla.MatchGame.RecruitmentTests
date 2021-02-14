using FluentAssertions;
using MatchGameEngine.MatchRules;
using MatchGameEngine.Models;
using NUnit.Framework;

namespace MatchGameEngine.UnitTests.MatchRules
{
    [TestFixture]
    public class ValueMatchRuleTests
    {
        [Test]
        public void ValueMatchRule_MatchSameValue_ReturnsTrue()
        {
            var rule = new ValueMatchRule();

            var result = rule.Match(new Card(Suit.Clubs, CardValue.Ace), new Card(Suit.Diamonds, CardValue.Ace));

            result.Should().BeTrue();
        }

        [Test]
        public void ValueMatchRule_MatchDifferentValue_ReturnsFalse()
        {
            var rule = new ValueMatchRule();

            var result = rule.Match(new Card(Suit.Clubs, CardValue.Ace), new Card(Suit.Clubs, CardValue.Jack));

            result.Should().BeFalse();
        }
    }
}
