using System;

namespace YahtzeeKata
{
    public class YahtzeeScorer
    {
        public static int ScoreOnes(string dices)
        {
            if (string.IsNullOrEmpty(dices))
                return 0;
            return 1;
        }
    }
}