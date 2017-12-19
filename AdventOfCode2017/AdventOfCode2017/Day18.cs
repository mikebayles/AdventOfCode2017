using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCode2017
{
    public class Day18
    {
        private readonly Dictionary<char, long> registers = new Dictionary<char, long>();
        public int instructionsSent = 0;

        public long Part1(string[] input)
        {
            return Process(input, true, 0, null, null);
        }

        public static long Part2(string[] input)
        {
            var l1 = new List<long>();
            var l2 = new List<long>();

            var p0 = new Day18();
            var p1 = new Day18();

            ThreadPool.QueueUserWorkItem(state => p0.Process(input, false, 0, l1, l2));
            ThreadPool.QueueUserWorkItem(state => p1.Process(input, false, 1, l2, l1));

            while (true)
            {
                Console.WriteLine(p1.instructionsSent);
            }

            return -1;
        }

        private long Process(string[] input, bool isPart1, int programId, List<long> inbound, List<long> outbound)
        {
            long lastFreq = 0;
            "abcdefghijklmnopqrstuvwxyz".ToList().ForEach(c => registers[c] = 0);

            registers['p'] = programId;

            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var parts = line.Split();
                var command = parts[0];

                string x;

                switch (command)
                {
                    case "snd":
                        if (isPart1)
                            lastFreq = GetRegisterValueOrParse(parts[1]);
                        else
                        {
                            lock (outbound)
                            {
                                outbound.Add(GetRegisterValueOrParse(parts[1]));
                                instructionsSent++;
                            }

                        }
                        break;
                    case "set":
                        x = parts[1];
                        registers[x[0]] = GetRegisterValueOrParse(parts[2]);
                        break;
                    case "add":
                        x = parts[1];
                        registers[x[0]] += GetRegisterValueOrParse(parts[2]);
                        break;
                    case "mul":
                        x = parts[1];
                        registers[x[0]] *= GetRegisterValueOrParse(parts[2]);
                        break;
                    case "mod":
                        x = parts[1];
                        registers[x[0]] %= GetRegisterValueOrParse(parts[2]);
                        break;
                    case "rcv":
                        x = parts[1];
                        if (GetRegisterValueOrParse(x) != 0 && isPart1)
                        {
                            return lastFreq;
                        }


                        while (!isPart1 && inbound.Count == 0)
                        {

                        }

                        lock (inbound)
                        {
                            if (!isPart1)
                            {
                                registers[x[0]] = inbound[0];
                                inbound.RemoveAt(0);
                            }
                        }

                        break;
                    case "jgz":
                        x = parts[1];
                        if (GetRegisterValueOrParse(x) > 0)
                        {
                            i += (int)GetRegisterValueOrParse(parts[2]);
                            i--;
                        }
                        break;
                    default:
                        throw new Exception("Unknown command " + command);

                }
            }

            return 0;
        }

        public long GetRegisterValueOrParse(string val)
        {
            long asLong;
            if (long.TryParse(val, out asLong))
                return asLong;

            return registers[val[0]];
        }
    }
}
