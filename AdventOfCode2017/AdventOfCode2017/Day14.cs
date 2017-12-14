using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day14
    {
        private static int size = 128;
        private int[,] arr = new int[size, size];
        List<Point> visited = new List<Point>();


        public int Part1(string input)
        {
            int ret = 0;
            var knotHasher = new Day10();

            for (int r = 0; r < 128; r++)
            {
                var hash = knotHasher.Part2($"{input}-{r}");
                var binString = string.Join(string.Empty, hash.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')).ToArray());
                for (int c = 0; c < binString.Length; c++)
                {
                    var asInt = int.Parse(binString[c].ToString());
                    arr[r, c] = asInt;
                    ret += asInt;
                }
            }

            return ret;
        }

        public int Part2(string input)
        {
            Part1(input);

            int groupCount = 0;

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    var point = new Point(r, c);
                    if (visited.Contains(point)) continue;
                    if (SafeAccess(r, c) == -1) continue;
                    if (arr[r, c] == 0) continue;

                    groupCount++;

                    Search(r, c);
                }
            }

            return groupCount;
        }

        void Search(int r, int c)
        {
            var point = new Point(r, c);
            if (visited.Contains(point)) return;
            if (SafeAccess(r, c) == -1) return;
            if (arr[r, c] == 0) return;


            visited.Add(point);

            Search(r + 1, c);
            Search(r - 1, c);
            Search(r, c + 1);
            Search(r, c - 1);

        }

        int SafeAccess(int r, int c)
        {
            try
            {
                return arr[r, c];
            }
            catch
            {
                return -1;
            }
        }
    }

    public class Point
    {
        public int R { get; }
        public int C { get; }

        public Point(int r, int c)
        {
            R = r;
            C = c;
        }

        protected bool Equals(Point other)
        {
            return R == other.R && C == other.C;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (R * 397) ^ C;
            }
        }
    }
}
