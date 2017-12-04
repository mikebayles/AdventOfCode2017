using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day4
    {
        public int Part1(string input)
        {
            int ret = 0;
            foreach (var line in input.Split('|'))
            {
                if (line.Split().Distinct().Count() == line.Split().Length)
                    ret++;
            }
            return ret;
        }

        public int Part2(string input)
        {
            int ret = 0;
            foreach (var line in input.Split('|'))
            {
                if (line.Split().Select(a => new string(a.OrderBy(b => b).ToArray())).ToArray().Distinct().Count() == line.Split().Length)
                    ret++;

            }
            return ret;
        }
    }
}
