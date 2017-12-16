using System;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day15
    {
        private const int GenAFactor = 16807;
        private const int GenBFactor = 48271;
        private const int CommonFactor = 2147483647;

        public int Part1(int a, int b)
        {
            int pairs = 0;
            long lastA = (a * GenAFactor) % CommonFactor;
            long lastB = (b * GenBFactor) % CommonFactor;


            foreach (var i in Enumerable.Range(0, 40000000))
            {
                string aBin = Convert.ToString(lastA, 2).PadLeft(16, '0');
                string bBin = Convert.ToString(lastB, 2).PadLeft(16, '0');

                if (aBin.Substring(aBin.Length - 16) == bBin.Substring(bBin.Length - 16))
                    pairs++;

                lastA = (lastA * GenAFactor) % CommonFactor;
                lastB = (lastB * GenBFactor) % CommonFactor;
            }

            return pairs;
        }

        public int Part2(int a, int b)
        {
            int pairs = 0;
            long lastA = GetNextValue(a, GenAFactor, 4);
            long lastB = GetNextValue(b, GenBFactor, 8);

            foreach (var i in Enumerable.Range(0, 5000000))
            {
                string aBin = Convert.ToString(lastA, 2).PadLeft(16, '0');
                string bBin = Convert.ToString(lastB, 2).PadLeft(16, '0');

                if (aBin.Substring(aBin.Length - 16) == bBin.Substring(bBin.Length - 16))
                    pairs++;

                lastA = GetNextValue(lastA, GenAFactor, 4);
                lastB = GetNextValue(lastB, GenBFactor, 8);
            }

            return pairs;
        }

        private long GetNextValue(long start, int factor, int criteria)
        {
            long ret = (start * factor) % CommonFactor;
            if (ret % criteria == 0)
                return ret;

            return GetNextValue(ret, factor, criteria);
        }
    }
}
