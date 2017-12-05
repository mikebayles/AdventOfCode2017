using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day5
    {
        public int Part1(string[] input)
        {
            return ExecuteInstructions(input, false);
        }

        public int Part2(string[] input)
        {
            return ExecuteInstructions(input, true);
        }

        private int ExecuteInstructions(string[] input, bool decrement)
        {
            int moves = 0;
            var lines = input.Select(a => int.Parse(a)).ToList();
            for (int i = 0; i < lines.Count;)
            {
                int num = lines[i];
                if (num >= 3 && decrement)
                    lines[i] = num - 1;
                else
                    lines[i] = num + 1;

                i += num;
                moves++;
            }

            return moves;
        }
    }
}
