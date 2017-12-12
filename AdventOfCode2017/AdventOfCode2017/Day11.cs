using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day11
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
            int x = 0;
            int y = 0;

            List<int> distances = new List<int>();

            foreach (var dir in input.Split(','))
            {
                switch (dir)
                {
                    case "ne":
                        y--;
                        x++;
                        break;
                    case "se":
                        x++;
                        y++;
                        break;
                    case "s":
                        y += 2;
                        break;
                    case "sw":
                        y++;
                        x--;
                        break;
                    case "nw":
                        x--;
                        y--;
                        break;
                    case "n":
                        y -= 2;
                        break;
                    default:
                        throw new Exception("Weird direction " + dir);

                }

                distances.Add((int)((Math.Abs(x) + Math.Abs(y)) / 2.0));
            }

            return part2 ? distances.Max() : distances.Last();
        }
    }
}
