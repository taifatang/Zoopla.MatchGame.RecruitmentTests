using FluentAssertions;
using MatchGameEngine.MatchRules;
using MatchGameEngine.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MatchGameEngine.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IDeckProvider> _deckProvider;
        private Mock<IMatchRule> _matchingRulemock;
        private Game game;

        private Player playerA;
        private Player playerB;
        private List<Card> cards;

        [SetUp]
        public void SetUp()
        {
            playerA = new Player();
            playerB = new Player();
            cards = new List<Card>(Deck.Standard);


            _matchingRulemock = new Mock<IMatchRule>();
            _deckProvider = new Mock<IDeckProvider>();

            game = new Game(_deckProvider.Object, new GameConfiguration(playerA,
                playerB,
                1,
                _matchingRulemock.Object));

            _deckProvider.Setup(x => x.GetCards(It.IsAny<int>())).Returns(GenerateTestDeck(1));
            _matchingRulemock.Setup(x => x.Match(It.IsAny<Card>(), It.IsAny<Card>())).Returns(true);
        }

        [Test]
        public void Game_Play_ReturnsWinner()
        {
            var result = game.Play();

            var expectedWinner = playerA.Cards.Count > playerB.Cards.Count ? playerA : playerB;
            result.Winner.Should().Be(expectedWinner);
            result.Status.Should().Be(Status.Victory);
            playerA.Cards.Should().NotBeEmpty();
            playerB.Cards.Should().NotBeEmpty();
        }

        [Test]
        public void Game_Play_UseMatchingRulesToDetermineWinner()
        {
            var result = game.Play();

            var expectedWinner = playerA.Cards.Count > playerB.Cards.Count ? playerA : playerB;
            result.Winner.Should().Be(expectedWinner);
            playerA.Cards.Should().NotBeEmpty();
            playerB.Cards.Should().NotBeEmpty();
            _matchingRulemock.Verify(x => x.Match(It.IsAny<Card>(), It.IsAny<Card>()));
        }

        [TestCase(1, 52)]
        [TestCase(2, 104)]
        [TestCase(3, 156)]
        public void Game_Play_UseNumberOfDecksSpecified(int deckCount, int expectedNumberOfCards)
        {
            game = new Game(_deckProvider.Object, new GameConfiguration(playerA,
                playerB,
                deckCount,
                _matchingRulemock.Object));
            _deckProvider.Setup(x => x.GetCards(deckCount)).Returns(GenerateTestDeck(deckCount));

            game.Play();

            _deckProvider.Verify(x => x.GetCards(deckCount), Times.Once);
            (playerA.Cards.Count + playerB.Cards.Count).Should().Be(expectedNumberOfCards);
        }

        [Test]
        public void Game_Play_ReturnsDrawForSameNumberOfCards()
        {
            _matchingRulemock.Setup(x => x.Match(It.IsAny<Card>(), It.IsAny<Card>())).Returns(false);
            
            var result = game.Play();

            playerA.Cards.Count.Should().Be(playerB.Cards.Count);
            result.Status.Should().Be(Status.Draw);
            result.Winner.Should().BeNull();
        }

        private List<Card> GenerateTestDeck(int count)
        {
            var deck = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                deck.AddRange(Deck.Standard);
            }

            return deck;
        }
    }
}
