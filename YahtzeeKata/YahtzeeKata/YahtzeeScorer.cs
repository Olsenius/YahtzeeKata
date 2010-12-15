using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class YahtzeeScorer
    {
        public static int ScoreOnes(string dices)
        {
            return SumDicesWithValue(dices, 1);
        }

        public static int ScoreTwos(string dices)
        {
            return SumDicesWithValue(dices, 2);
        }

        public static int ScoreThrees(string dices)
        {
            return SumDicesWithValue(dices, 3);
        }

        public static int ScoreFours(string dices)
        {
            return SumDicesWithValue(dices, 4);
        }

        public static int ScoreFives(string dices)
        {
            return SumDicesWithValue(dices, 5);
        }

        public static int ScoreSixes(string dices)
        {
            return SumDicesWithValue(dices, 6);
        }

        private static int SumDicesWithValue(string dices, int value)
        {
            var numberOfDicesWithMatchingValue = ParseToInt(dices).Count(x => x == value);
            return numberOfDicesWithMatchingValue * value;
        }

        public static int ScorePair(string dices)
        {
            return ScorePairs(dices, 1);
        }

        private static IEnumerable<int> ParseToInt(string dices)
        {
            return (dices ?? String.Empty).Select(x => Int32.Parse(x.ToString()));
        }


        public static object ScoreTwoPairs(string dices)
        {
            return ScorePairs(dices, 2);
        }

        private static int ScorePairs(string dices, int numberOfPairs)
        {
            var pairs = ParseToInt(dices).GroupBy(x => x)
                .Where(t => t.Count() >= 2)
                .OrderByDescending(u => u.Key);

            if (pairs.Count() < numberOfPairs)
                return 0;

            return pairs.Take(numberOfPairs).Select(x => x.Key * 2).Sum();
        }
    }
}