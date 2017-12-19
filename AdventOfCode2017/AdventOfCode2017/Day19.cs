namespace AdventOfCode2017
{
    public class PointWithValue : Point
    {
        public PointWithValue(int r, int c) : base(r, c)
        {
        }

        public char Value { get; set; }
    }

    public class Day19
    {
        private int rows, columns;
        private readonly int startColumn;
        private int steps;
        private readonly char[,] map;

        public Day19(string[] input)
        {
            rows = input.Length;
            columns = input[0].Length;
            map = new char[rows, columns];


            for (int r = 0; r < input.Length; r++)
            {
                var row = input[r];
                for (int c = 0; c < row.Length; c++)
                {
                    map[r, c] = row[c];

                    if (r == 0 && row[c] == '|')
                        startColumn = c;

                }
            }
        }

        public string Part1()
        {
            return Walk(0, startColumn);
        }

        public int Part2()
        {
            Walk(0, startColumn);
            return steps;
        }

        private string Walk(int r, int c)
        {
            string ret = "";
            var current = map[r, c];
            var lastDirection = 'D';

            while (current != ' ')
            {
                steps++;
                switch (lastDirection)
                {
                    case 'D':
                        r++;
                        break;
                    case 'L':
                        c--;
                        break;
                    case 'U':
                        r--;
                        break;
                    case 'R':
                        c++;
                        break;
                }

                current = map[r, c];

                var right = SafeAccess(r, c + 1);
                var up = SafeAccess(r - 1, c);

                if (current == '+')
                {
                    if (lastDirection == 'D' || lastDirection == 'U')
                        lastDirection = right != ' ' ? 'R' : 'L';
                    else
                        lastDirection = up != ' ' ? 'U' : 'D';
                }
                else if (char.IsLetter(current))
                    ret += current;

            }

            return ret;
        }

        private char SafeAccess(int r, int c)
        {
            try
            {
                return map[r, c];
            }
            catch
            {
                return ' ';
            }
        }
    }
}
