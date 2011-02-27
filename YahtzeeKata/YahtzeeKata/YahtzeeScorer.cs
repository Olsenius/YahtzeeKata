using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private static IEnumerable<int> ParseToInt(string dices)
        {
            return (dices ?? String.Empty).Select(x => Int32.Parse(x.ToString()));
        }

        public static int ScorePair(string dices)
        {
            return ScoreMultiples(dices, 2, 1);
        }

        public static int ScoreTwoPairs(string dices)
        {
            return ScoreMultiples(dices, 2, 2);
        }

        public static int ScoreThreeOfAKind(string dices)
        {
            return ScoreMultiples(dices, 3, 1);
        }

        public static int ScoreFourOfAKind(string dices)
        {
            return ScoreMultiples(dices, 4, 1);
        }


        private static int ScoreMultiples(string dices, int numberOfSameDices, int repititions)
        {
            var sum = 0;
            var remainingDices = dices;

            for (int i = 0; i < repititions; i++)
            {
                if (!HasMultiples(remainingDices, numberOfSameDices))
                    return 0;

                sum += TakeBestMultiples(remainingDices, numberOfSameDices);
                remainingDices = RemoveUsedDices(remainingDices, numberOfSameDices);
            }

            return sum;
        }

        private static int TakeBestMultiples(string remainingDices, int numberOfSameDices)
        {
            return BestMultipleDice(remainingDices, numberOfSameDices)
                .Sum(x => Convert.ToInt32(x.ToString()) * numberOfSameDices);
        }

        private static string RemoveUsedDices(string dices, int numberOfSameDices)
        {
            var remainingDices = dices;
            var bestdice = BestMultipleDice(dices, numberOfSameDices);
            for (int i = 0; i < numberOfSameDices; i++)
            {
                var sb = new StringBuilder(remainingDices);
                sb.Remove(remainingDices.IndexOf(bestdice), 1);
                remainingDices = sb.ToString();
            }
            return remainingDices;
        }

        private static string BestMultipleDice(string dices, int numberOfSameDices)
        {
            return dices.GroupBy(x => x)
                .Where(t => t.Count() >= numberOfSameDices)
                .OrderByDescending(u => u.Key)
                .FirstOrDefault()
                .Key
                .ToString();
        }

        private static bool HasMultiples(string dices, int numberOfSameDices)
        {
            return dices.GroupBy(x => x).Any(x => x.Count() >= numberOfSameDices);
        }

        public static int ScoreFullHouse(string dices)
        {
            throw new NotImplementedException();
        }
    }
}