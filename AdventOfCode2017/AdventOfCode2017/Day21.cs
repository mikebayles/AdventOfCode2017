using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day21
    {
        private List<Rule> rules;

        public Day21(string[] input)
        {
            rules = input.Select(a => new Rule(a.Split()[0], a.Split()[2])).ToList();
        }

        public int Part1(int iterations)
        {
            char[,] drawing = stringToCharArr(".#./..#/###");
            while (iterations-- > 0)
            {
                int size = drawing.GetLength(0);

                var newDrawings = ArraySplit(drawing, size % 2 == 0 ? 2 : 3);
                var drawingsToMerge = new List<char[,]>();

                foreach (var newDrawing in newDrawings)
                {
                    var asString = charArrToString(newDrawing);
                    var rule = rules.First(a => a.Matches.Any(m => m == asString));
                    if (rule != null)
                    {
                        asString = rule.Apply;
                    }

                    drawingsToMerge.Add(stringToCharArr(asString));

                }

                drawing = merge(drawingsToMerge);
            }


            return charArrToString(drawing).Count(a => a == '#');
        }

        private char[,] merge(List<char[,]> arrays)
        {
            int size = arrays[0].GetLength(0);
            int newSize = (int)Math.Sqrt(size * size * arrays.Count);

            var ret = new char[newSize, newSize];

            for (int i = 0; i < arrays.Count; i++)
            {
                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        int ri = (r / size) >= 1 ? (r / size) + 1 : (r / size);
                        int ci = c + size * (i % size);
                        ret[r + size * ((i + 1) / size), c + size * (i % (int)Math.Sqrt(arrays.Count))] = arrays[i][r, c];
                    }
                }
            }

            return ret;
        }

        public static char[,] stringToCharArr(string drawing)
        {
            var rows = drawing.Split('/');
            var ret = new char[rows.Length, rows.Length];
            for (int r = 0; r < rows.Length; r++)
            {
                var row = rows[r];
                for (int c = 0; c < row.Length; c++)
                {
                    ret[r, c] = row[c];
                }
            }

            return ret;
        }

        public static string charArrToString(char[,] array)
        {
            StringBuilder ret = new StringBuilder();
            int rows = array.GetLength(0);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < rows; c++)
                {
                    ret.Append(array[r, c]);
                }
                ret.Append("/");
            }

            return ret.ToString().TrimEnd('/');
        }

        private List<char[,]> ArraySplit(char[,] array, int size)
        {
            List<char[,]> ret = new List<char[,]>();
            for (int i = 0; i < (array.GetLength(0) * array.GetLength(1)) / (size * size); i++)
            {
                ret.Add(new char[size, size]);
            }


            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    int n = (r * array.GetLength(0)) + c;
                    if (ret.Count == 1)
                        ret[0][r % size, c % size] = array[r, c];
                    else
                        ret[(n % array.GetLength(0) / size)][r % size, c % size] = array[r, c];
                }
            }

            foreach (var a in ret)
            {
                if (charArrToString(a).Contains(default(char)))
                {
                    Console.WriteLine("adf");
                }
            }



            return ret;
        }
    }

    public class Rule
    {
        public List<string> Matches { get; }
        public string Apply { get; }

        private string match;

        public Rule(string match, string apply)
        {
            this.match = match;
            Matches = new List<string>();
            Apply = apply;

            Matches.Add(match);
            Matches.Add(Day21.charArrToString(flip(Day21.stringToCharArr(Matches[0]), true)));
            Matches.Add(Day21.charArrToString(flip(Day21.stringToCharArr(Matches[0]), false)));
            createRotations();
            foreach (var s in Matches)
            {
                Console.WriteLine(s);
            }
        }

        private void createRotations()
        {
            foreach (var i in Enumerable.Range(0, Matches.Count))
            {
                Matches.Add(Day21.charArrToString(rotate(Day21.stringToCharArr(Matches[i]))));
            }
        }

        private char[,] flip(char[,] arr, bool verticle)
        {
            var size = arr.GetLength(0);
            var ret = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (verticle)
                        ret[r, c] = arr[(size - r - 1), c];
                    else
                        ret[r, c] = arr[r, (size - c - 1)];
                }
            }

            return ret;
        }

        private char[,] rotate(char[,] arr)
        {
            var size = arr.GetLength(0);

            var ret = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    ret[r, c] = arr[size - c - 1, r];
                }
            }

            return ret;
        }
    }
}
