using System;
using System.Linq;

namespace YahtzeeKata
{
    public class YahtzeeScorer
    {
        public static int ScoreOnes(string dices)
        {
            if (string.IsNullOrEmpty(dices))
                return 0;
            else {
                var ones = from d in dices where d.Equals('1') select d;
                return ones.Count();
                }
        }
    }
}