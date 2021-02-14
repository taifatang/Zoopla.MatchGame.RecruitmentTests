using FluentAssertions;
using MatchGameEngine.Models;
using Moq;
using NUnit.Framework;

namespace MatchGameEngine.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IDeckProvider> _deckProvider;
        private Game game;

        private Player playerA;
        private Player playerB;

        [SetUp]
        public void SetUp()
        {
            playerA = new Player();
            playerB = new Player();

            _deckProvider = new Mock<IDeckProvider>();
            game = new Game(_deckProvider.Object);
        }

        [Test]
        public void Game_Play_ReturnsWinner()
        {
            _deckProvider.Setup(x => x.GetDeck()).Returns(new System.Collections.Generic.List<Card>()
            {
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card()
            });

            var winner = game.Play(new[] { playerA, playerB });

            var expectedWinner = playerA.Cards.Count > playerB.Cards.Count ? playerA : playerB;
            winner.Should().Be(expectedWinner);
            playerA.Cards.Should().NotBeEmpty();
            playerB.Cards.Should().NotBeEmpty();
        }
    }
}
