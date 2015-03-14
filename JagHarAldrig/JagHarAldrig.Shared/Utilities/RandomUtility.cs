using System;
using System.Collections.Generic;
using System.Text;

namespace JagHarAldrig.Utilities
{
    public static class RandomUtility
    {
        static Random random;

        static RandomUtility()
        {
            random = new Random();
        }

        public static int GenerateNumber(int from, int to)
        {
            return random.Next(from, to + 1);
        }
    }
}
