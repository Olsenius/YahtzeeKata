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
            return ScoreMultiples(dices, 2, 1);
        }

        private static IEnumerable<int> ParseToInt(string dices)
        {
            return (dices ?? String.Empty).Select(x => Int32.Parse(x.ToString()));
        }


        public static object ScoreTwoPairs(string dices)
        {
            return ScoreMultiples(dices, 2,2);
        }

        private static int ScoreMultiples(string dices, int numberofSameDices, int repetitions)
        {
            int sum = 0;
            string dicesNow = dices;
            for (int n = 1; n <= repetitions; n++)
            {
                string dicesLeft;
                var result = GetSame(dicesNow, numberofSameDices, out dicesLeft);
                if (string.IsNullOrEmpty(result)) return 0;

                sum += ParseToInt(result).Sum();
                dicesNow = dicesLeft;

            }
            return sum;
        }

        private static string GetSame(string dices, int numberOfSame, out string dicesleft)
        {
            dicesleft = dices;
            var same = dices.GroupBy(x => x)
                .Where(t => t.Count() >= numberOfSame)
                .OrderByDescending(u => u.Key)
                .FirstOrDefault();

            if (same != null && same.Count() >= numberOfSame)
            {
                dicesleft = dices.Remove(dices.IndexOf(same.First()), numberOfSame);
                return new string(same.Take(numberOfSame).ToArray());
            }
            return "";

        }

        public static int ScoreThreeOfAKind(string dices)
        {
            return ScoreMultiples(dices, 3, 1);
        }

        public static int ScoreFourOfAKind(string dices)
        {
            return ScoreMultiples(dices, 4, 1);
        }
    }
}