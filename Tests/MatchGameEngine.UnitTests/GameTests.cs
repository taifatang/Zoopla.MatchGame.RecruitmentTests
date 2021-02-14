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
        private Game _game;

        private Player _playerA;
        private Player _playerB;

        [SetUp]
        public void SetUp()
        {
            _playerA = new Player("playerA");
            _playerB = new Player("playerB");
            var numberOfDecks = 1;

            _matchingRulemock = new Mock<IMatchRule>();
            _deckProvider = new Mock<IDeckProvider>();

            _game = new Game(_deckProvider.Object, new GameConfiguration(_playerA,
                _playerB,
                numberOfDecks,
                _matchingRulemock.Object));

            _deckProvider.Setup(x => x.GetCards(It.IsAny<int>())).Returns(GenerateTestDeck(numberOfDecks));
            _matchingRulemock.Setup(x => x.Match(It.IsAny<Card>(), It.IsAny<Card>())).Returns(true);
        }

        [Test]
        public void Game_Play_ReturnsWinner()
        {
            var deckWithOddNumberOfCards = new List<Card>(Deck.Standard)
            {
                new Card(Suit.Clubs, CardValue.Ace),
            };
            _deckProvider.Setup(x => x.GetCards(It.IsAny<int>())).Returns(deckWithOddNumberOfCards);

            var result = _game.Play();

            var expectedWinner = _playerA.Cards.Count > _playerB.Cards.Count ? _playerA : _playerB;
            result.Status.Should().Be(Status.Victory);
            result.Winner.Should().Be(expectedWinner);
            _playerA.Cards.Should().NotBeEmpty();
            _playerB.Cards.Should().NotBeEmpty();
        }

        [Test]
        public void Game_Play_UseMatchingRulesToDetermineWinner()
        {
            _deckProvider.Setup(x => x.GetCards(It.IsAny<int>())).Returns(new List<Card>
            {
                new Card(Suit.Clubs, CardValue.Ace),
                new Card(Suit.Clubs, CardValue.Two),
                new Card(Suit.Clubs, CardValue.Three),
            });

            var result = _game.Play();

            var expectedWinner = _playerA.Cards.Count > _playerB.Cards.Count ? _playerA : _playerB;
            result.Winner.Should().Be(expectedWinner);
            _matchingRulemock.Verify(x => x.Match(It.IsAny<Card>(), It.IsAny<Card>()));
        }

        [TestCase(1, 52)]
        [TestCase(2, 104)]
        [TestCase(3, 156)]
        public void Game_Play_UseNumberOfDecksSpecified(int deckCount, int expectedNumberOfCards)
        {
            _game = new Game(_deckProvider.Object, new GameConfiguration(_playerA,
                _playerB,
                deckCount,
                _matchingRulemock.Object));
            _deckProvider.Setup(x => x.GetCards(deckCount)).Returns(GenerateTestDeck(deckCount));

            _game.Play();

            _deckProvider.Verify(x => x.GetCards(deckCount), Times.Once);
            (_playerA.Cards.Count + _playerB.Cards.Count).Should().Be(expectedNumberOfCards);
        }

        [Test]
        public void Game_Play_ReturnsDrawForSameNumberOfCards()
        {
            _matchingRulemock.Setup(x => x.Match(It.IsAny<Card>(), It.IsAny<Card>())).Returns(false);
            
            var result = _game.Play();

            _playerA.Cards.Count.Should().Be(_playerB.Cards.Count);
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
