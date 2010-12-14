using NUnit.Framework;
using System;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeScorerTests
    {

        [TestCase(null, 0)]
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("112", 2)]
        public void Score_ones_should_score_ones_correct(string dices, int expectedSum)
        {
            YahtzeeScorer.ScoreOnes(dices).ShouldEqual(expectedSum);
        }

        [TestCase("", 0)]
        [TestCase("2", 2)]
        [TestCase("212", 4)]
        public void Score_twos_should_score_twos_correct(string dices, int expectedSum)
        {
            YahtzeeScorer.ScoreTwos(dices).ShouldEqual(expectedSum);
        }

        [TestCase("", 0)]
        [TestCase("3", 3)]
        [TestCase("313", 6)]
        public void Score_threes_should_score_threes_correct(string dices, int expectedSum)
        {
            YahtzeeScorer.ScoreThrees(dices).ShouldEqual(expectedSum);
        }

        [TestCase("", 0)]
        [TestCase("4", 4)]
        [TestCase("414", 8)]
        public void Score_fours_should_score_fours_correct(string dices, int expectedSum)
        {
            YahtzeeScorer.ScoreFours(dices).ShouldEqual(expectedSum);
        }

        [TestCase("", 0)]
        [TestCase("5", 5)]
        [TestCase("515", 10)]
        public void Score_fives_should_score_fives_correct(string dices, int expectedSum)
        {
            YahtzeeScorer.ScoreFives(dices).ShouldEqual(expectedSum);
        }

        [TestCase("", 0)]
        [TestCase("6", 6)]
        [TestCase("616", 12)]
        public void Score_sixes_should_score_sixes_correct(string dices, int expectedSum)
        {
            YahtzeeScorer.ScoreSixes(dices).ShouldEqual(expectedSum);
        }

        [Test]
        public void Score_pair_should_score_zero_when_no_dices()
        {
            YahtzeeScorer.ScorePair("").ShouldEqual(0);
        }

        [Test]
        public void Score_pair_should_score_pair_when_pair_in_dices()
        {
            YahtzeeScorer.ScorePair("11").ShouldEqual(2);
        }

        [TestCase("11133", 6)]
        [TestCase("11333", 6)]
        [TestCase("55533", 10)]
        public void Score_pair_should_score_highest_pair(string dices, int expectedSum)
        {
            YahtzeeScorer.ScorePair(dices).ShouldEqual(expectedSum);
        }

        [Test]
        public void Score_two_pairs_should_score_zero_when_no_dices()
        {
            YahtzeeScorer.ScoreTwoPairs("").ShouldEqual(0);
        }

        [Test]
        public void Score_two_pairs_should_score_zero_when_one_pair()
        {
            YahtzeeScorer.ScoreTwoPairs("11").ShouldEqual(0);
        }

        [Test]
        public void Score_two_pairs_should_score_two_pairs_correct()
        {
            YahtzeeScorer.ScoreTwoPairs("1122").ShouldEqual(6);
            YahtzeeScorer.ScoreTwoPairs("112233").ShouldEqual(10);
        }
    }
}