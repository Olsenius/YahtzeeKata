using System;
using System.Linq;

namespace YahtzeeKata
{
    public class YahtzeeScorer
    {
        public static int ScoreOnes(string dices)
        {
            return (dices ?? string.Empty).Where(d => d.Equals('1')).Count();
        }

        public static int ScoreTwos(string dices)
        {
            return (dices ?? string.Empty).Where(d => d.Equals('2')).Count() * 2;
        }
    }
}