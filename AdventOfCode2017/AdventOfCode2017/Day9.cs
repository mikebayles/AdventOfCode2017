using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day9
    {
        public int Part1(string input)
        {
            return Calculate(input, false);
        }

        public int Part2(string input)
        {
            return Calculate(input, true);
        }

        private int Calculate(string input, bool part2)
        {
            int bracketCount = 0;
            int garbageCount = 0;
            int currentDepth = 1;
            bool inGarbage = false;

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];

                switch (c)
                {
                    case '{':
                        if (!inGarbage)
                            bracketCount += currentDepth++;
                        else
                            garbageCount++;
                        break;
                    case '}':
                        if (!inGarbage)
                            currentDepth--;
                        else
                            garbageCount++;
                        break;
                    case '<':
                        if (inGarbage)
                            garbageCount++;
                        inGarbage = true;
                        break;
                    case '>':
                        inGarbage = false;
                        break;
                    case '!':
                        i++;
                        break;
                    default:
                        if (inGarbage)
                            garbageCount++;
                        break;
                }
            }

            return part2 ? garbageCount : bracketCount;
        }
    }
}