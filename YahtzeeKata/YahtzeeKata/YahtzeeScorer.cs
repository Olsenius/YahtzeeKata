using System;
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
            var numberOfDicesWithMatchingValue = (dices ?? string.Empty).Where(d => Int32.Parse(d.ToString()) == value).Count();
            return numberOfDicesWithMatchingValue * value;
        }
    }
}