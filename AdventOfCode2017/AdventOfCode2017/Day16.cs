using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day16
    {
        List<string> seen = new List<string>();
        public string Part1(string ret, string input, int iteration)
        {
            if (seen.Contains(ret))
            {
                throw new Exception(seen[1000000000 % iteration]);
            }

            seen.Add(ret);


            foreach (var command in input.Split(','))
            {
                var commandPrefix = command[0];
                switch (commandPrefix)
                {
                    case 'x':
                        var parts = command.Substring(1).Split('/');
                        var a = int.Parse(parts[0]);
                        var b = int.Parse(parts[1]);

                        var letterA = ret[a];
                        var letterB = ret[b];

                        ret = ret.Remove(a, 1);
                        ret = ret.Insert(a, letterB.ToString());

                        ret = ret.Remove(b, 1);
                        ret = ret.Insert(b, letterA.ToString());

                        break;
                    case 'p':
                        var parterParts = command.Substring(1).Split('/');
                        var partnerA = parterParts[0][0];
                        var partnerB = parterParts[1][0];

                        var indexA = ret.IndexOf(partnerA);
                        var indexB = ret.IndexOf(partnerB);

                        ret = ret.Remove(indexA, 1);
                        ret = ret.Insert(indexA, partnerB.ToString());

                        ret = ret.Remove(indexB, 1);
                        ret = ret.Insert(indexB, partnerA.ToString());

                        break;
                    case 's':
                        var num = int.Parse(new string(command.Skip(1).ToArray()));
                        var charsToMove = ret.Substring(ret.Length - num);
                        ret = ret.Insert(0, charsToMove);
                        ret = ret.Remove(ret.Length - num);
                        break;
                    default:
                        throw new Exception("Unknown command " + commandPrefix);
                }
            }

            return ret;
        }

        public string Part2(string ret, string input)
        {
            for (int i = 0; i < 1000000000; i++)
            {
                ret = Part1(ret, input, i);
            }

            return ret;
        }
    }
}
