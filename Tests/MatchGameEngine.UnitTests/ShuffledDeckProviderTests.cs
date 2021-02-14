using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchGameEngine.UnitTests
{
    [TestFixture]
    public class ShuffledDeckProviderTests
    {
        [Test]
        public void DeckProvider_GetCards_ReturnsShuffledDeck()
        {
            var provider = new ShuffledDeckProvider();

            var cards = provider.GetCards(1);

            cards.Should().NotBeEmpty();
            cards.Should().NotEqual(Deck.Standard);
            cards.Count.Should().Be(52);
        }

        [TestCase(1, 52)]
        [TestCase(2, 104)]
        [TestCase(3, 156)]
        public void DeckProvider_GetCards_ReturnsMultipleShuffledDeck(int deckCount, int expectedNumberOfCards)
        {
            var provider = new ShuffledDeckProvider();

            var cards = provider.GetCards(deckCount);

            cards.Count.Should().Be(expectedNumberOfCards);
        }
    }
}
