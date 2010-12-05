using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeScorerTests
    {
        [Test]
        public void Score_ones_should_score_zero_when_no_dices()
        {
            var score = YahtzeeScorer.ScoreOnes(string.Empty);
            score.ShouldEqual(0);
        }
    }
}