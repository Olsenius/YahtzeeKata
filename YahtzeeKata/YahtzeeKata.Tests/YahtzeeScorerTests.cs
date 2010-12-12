using NUnit.Framework;
using System;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeScorerTests
    {

        [TestCase(null, ScoreType.Ones, 0)]
        [TestCase("", ScoreType.Ones, 0)]
        [TestCase("1", ScoreType.Ones, 1)]
        [TestCase("112", ScoreType.Ones, 2)]
        [TestCase("11111", ScoreType.Ones, 5)]
        [TestCase("11311", ScoreType.Ones, 4)]
        [TestCase("2", ScoreType.Twos, 2)]
        [TestCase("212", ScoreType.Twos, 4)]
        [TestCase("2121222", ScoreType.Twos, 10)]
        [TestCase("3", ScoreType.Threes, 3)]
        [TestCase("313", ScoreType.Threes, 6)]
        [TestCase("4", ScoreType.Fours, 4)]
        [TestCase("414", ScoreType.Fours, 8)]
        [TestCase("5", ScoreType.Fives, 5)]
        [TestCase("515", ScoreType.Fives, 10)]
        [TestCase("6", ScoreType.Sixes, 6)]
        [TestCase("616", ScoreType.Sixes, 12)]
        [TestCase("66666", ScoreType.Sixes, 30)]

        public void Score_numbers_should_score_numbers_correct(string dices, ScoreType type, int expectedSum)
        {
            YahtzeeScorer.Score(dices, type).ShouldEqual(expectedSum);
        }

        [Test]
        public void Score_pair_should_score_zero_when_no_dices()
        {
            YahtzeeScorer.Score("1", ScoreType.Pair).ShouldEqual(0);
        }

        [Test]
        public void Score_pair_should_score_pair_when_pair_in_dices()
        {
            YahtzeeScorer.Score("11", ScoreType.Pair).ShouldEqual(2);
        }

        [Test]
        public void Score_pair_should_score_highest_pair()
        {
            YahtzeeScorer.Score("11133", ScoreType.Pair).ShouldEqual(6);
        }

    }
}