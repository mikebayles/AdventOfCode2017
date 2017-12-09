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
            int ret = 0;
            int currentDepth = 1;
            bool inGarbage = false;

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];

                switch (c)
                {
                    case '{':
                        if (!inGarbage)
                            ret += currentDepth++;
                        break;
                    case '}':
                        if (!inGarbage)
                            currentDepth--;
                        break;
                    case '<':
                        inGarbage = true;
                        break;
                    case '>':
                        inGarbage = false;
                        break;
                    case '!':
                        i++;
                        break;
                    default:
                        break;
                }
            }

            return ret;
        }

        public int Part2(string input)
        {
            int ret = 0;
            bool inGarbage = false;

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];

                switch (c)
                {
                    case '<':
                        if (inGarbage) ret++;
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
                            ret++;
                        break;
                }
            }

            return ret;
        }
    }
}
