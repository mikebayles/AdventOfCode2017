using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day17
    {
        public int Part1(int input)
        {
            List<int> buffer = new List<int>() { 0 };
            int pos = 0;

            foreach (var i in Enumerable.Range(1, 2017))
            {
                pos = (pos + input) % buffer.Count;
                pos++;
                buffer.Insert(pos, i);
            }

            return buffer[pos + 1];
        }

        public int Part2(int input)
        {
            int pos = 0, value = 0;
            foreach (var i in Enumerable.Range(1, 50000000))
            {
                pos = ((pos + input) % i) + 1;
                if (pos == 1)
                {
                    value = i;
                }
            }

            return value;
        }
    }
}
