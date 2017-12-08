using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day6
    {
        public int Part1(string input)
        {
            return CalculateCycles(input, 1);
        }

        public int Part2(string input)
        {
            return CalculateCycles(input, 2) - CalculateCycles(input, 1);
        }

        private int CalculateCycles(string input, int threshold)
        {
            Dictionary<string, int> configurations = new Dictionary<string, int>();
            List<int> nums = input.Split().Select(a => int.Parse(a)).ToList();
            int cycles = 0;

            while (true)
            {
                cycles++;
                int max = nums.Max();
                int maxIndex = nums.IndexOf(max);
                nums[maxIndex] = 0;
                maxIndex++;

                while (max > 0)
                {
                    if (maxIndex >= nums.Count)
                        maxIndex = 0;

                    nums[maxIndex]++;
                    max--;
                    maxIndex++;
                }

                var asString = string.Join(" ", nums.Select(a => a.ToString()).ToArray());
                if (!configurations.ContainsKey(asString))
                {
                    configurations[asString] = 0;
                }

                if (++configurations[asString] > threshold)
                    break;
            }
            return cycles;
        }
    }
}
