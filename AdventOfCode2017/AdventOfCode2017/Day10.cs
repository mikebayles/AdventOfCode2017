using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day10
    {
        public int Part1(string input)
        {
            var numbers = Enumerable.Range(0, 256).ToList();
            int currentPos = 0;
            int skipSize = 0;

            foreach (var length in input.Split(',').Select(a => int.Parse(a)))
            {
                var reversed = new List<int>();

                while (reversed.Count < length)
                {
                    reversed.Add(numbers[(currentPos + reversed.Count) % numbers.Count]);
                }

                reversed.Reverse();

                int modified = 0;
                while (modified < length)
                {
                    numbers[(currentPos + modified) % numbers.Count] = reversed[modified];
                    modified++;
                }

                currentPos = (currentPos + length + skipSize) % numbers.Count;
                skipSize++;
            }


            return numbers[0] * numbers[1];
        }

        public string Part2(string input)
        {
            var ascii = input.Select(a => (int)a).ToList();
            ascii.AddRange(new List<int> { 17, 31, 73, 47, 23 });


            var numbers = Enumerable.Range(0, 256).ToList();
            int currentPos = 0;
            int skipSize = 0;
            int rounds = 64;
            while (rounds > 0)
            {
                foreach (var length in ascii)
                {
                    var reversed = new List<int>();

                    while (reversed.Count < length)
                    {
                        reversed.Add(numbers[(currentPos + reversed.Count) % numbers.Count]);
                    }

                    reversed.Reverse();

                    int modified = 0;
                    while (modified < length)
                    {
                        numbers[(currentPos + modified) % numbers.Count] = reversed[modified];
                        modified++;
                    }
                    currentPos = (currentPos + length + skipSize) % numbers.Count;
                    skipSize++;
                }

                rounds--;
            }

            List<int> denseHash = new List<int>();

            for (int i = 0; i < numbers.Count; i += 16)
            {
                denseHash.Add(numbers.Skip(i).Take(16).Aggregate((a, b) => a ^ b));
            }

            return string.Join("", denseHash.Select(a => a.ToString("x2")).ToArray());
        }
    }
}
