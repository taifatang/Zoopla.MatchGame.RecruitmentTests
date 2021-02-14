using NUnit.Framework;
using TestStack.BDDfy;

namespace MatchGameEngine.IntergrationTests
{
    [Story(
        AsA = "As an player",
        IWant = "I want to match with a bot",
        SoThat = "So that I am happy")]
    public class MatchGameEngineFeature
    {
        [Test]
        public void PlayMatchGame()
        {
            this.Given(_ => GivenIAmPlayingAgainstABotWithSlowReactionTime())
                 .When(_ => WhenIPlayMatchGame())
                 .Then(_ => ThenIWin())
                 .BDDfy();
        }

        private void GivenIAmPlayingAgainstABotWithSlowReactionTime()
        {

        }

        private void WhenIPlayMatchGame()
        {

        }

        private void ThenIWin()
        {

        }
    }
}
