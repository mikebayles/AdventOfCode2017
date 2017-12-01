using System.Linq;

namespace AdventOfCode2017
{
    public class Day1
    {
        public int Part1(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                int num = int.Parse(input[i].ToString());
                int next = int.Parse(input[i + 1].ToString());

                if (num == next)
                {
                    sum += num;
                }
            }

            if (input.Last() == input.First())
            {
                int num = int.Parse(input[0].ToString());
                sum += num;
            }
            return sum;
        }

        public int Part2(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length / 2; i++)
            {
                int num = int.Parse(input[i].ToString());
                int next = int.Parse(input[i + input.Length / 2].ToString());

                if (num == next)
                {
                    sum += num + num;
                }
            }
            return sum;
        }
    }
}
