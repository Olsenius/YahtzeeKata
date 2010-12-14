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
            var numbersGroupedByValue = ParseToInt(dices).GroupBy(x => x);

            if (numbersGroupedByValue.Any(IsPair))
                return numbersGroupedByValue.First(IsPair).First() * 2;
            return 0;
        }

        private static IEnumerable<int> ParseToInt(string dices)
        {
            return (dices ?? string.Empty).Select(x => Int32.Parse(x.ToString()));
        }

        private static bool IsPair(IGrouping<int,int> dices)
        {
            return dices.Count() == 2;
        }

        public static object ScoreTwoPairs(string p)
        {
            throw new NotImplementedException();
        }
    }
}