using NUnit.Framework;
using System;

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
        [Test]
        public void Score_ones_should_score_zero_when_null_dices()
        {
            var score = YahtzeeScorer.ScoreOnes(null);
            score.ShouldEqual(0);
        }
  
        [Test]
        public void Score_ones_should_score_one_when_one_correct_dice()
        {
            var score = YahtzeeScorer.ScoreOnes("1");
            score.ShouldEqual(1);
        }
  
        [Test]
        public void Score_ones_should_only_count_ones()
        {
            var score = YahtzeeScorer.ScoreOnes("2");
            score.ShouldEqual(0);
        }

        [Test]
        public void Score_ones_should_count_all_ones()
        {
            var score = YahtzeeScorer.ScoreOnes("121");
            score.ShouldEqual(2);
        }



        [Test]
        public void Score_twos_should_score_two_when_one_correct_dice()
        {
            var score = YahtzeeScorer.ScoreTwos("2");
            score.ShouldEqual(2);
        }


    }
}