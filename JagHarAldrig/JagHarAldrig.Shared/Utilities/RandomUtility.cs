using System;
using System.Collections.Generic;
using System.Text;

namespace JagHarAldrig.Utilities
{
    public static class RandomUtility
    {
        static Random random = new Random();
        static int lastValue;

        public static int GenerateNumber(int from, int to)
        {
            int value;
            do
            {
                value = random.Next(from, to);
            }
            while (value == lastValue);
            lastValue = value;
            return value;
        }
    }
}
