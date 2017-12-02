using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day2
    {

        public int Part1(string input)
        {
            int sum = 0;
            foreach (var line in input.Split('|'))
            {
                var nums = line.Split().Select(a => int.Parse(a));
                sum += nums.Max() - nums.Min();
            }

            return sum;
        }

        public int Part2(string input)
        {
            int sum = 0;
            foreach (var line in input.Split('|'))
            {
                var nums = line.Split().Select(a => int.Parse(a)).ToList();

                for (int i = 0; i < nums.Count; i++)
                {
                    for (int j = i + 1; j < nums.Count; j++)
                    {
                        int top = Math.Max(nums[i], nums[j]);
                        int bottom = Math.Min(nums[i], nums[j]);

                        if (top % bottom == 0)
                        {
                            sum += top / bottom;
                        }
                    }
                }
            }

            return sum;
        }
    }
}
