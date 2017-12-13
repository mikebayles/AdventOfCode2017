using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day13
    {
        private readonly List<FireWall> firewalls = new List<FireWall>();

        public Day13(string[] input)
        {
            foreach (var line in input)
            {
                var parts = line.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int depth = int.Parse(parts[0]);
                int range = int.Parse(parts[1]);

                firewalls.Add(new FireWall(depth, range));
            }
        }
        public int Part1()
        {
            return CalculateSeverity(0);
        }

        public int Part2()
        {
            int delay = 0;
            while (CalculateSeverity(delay) > 0)
                delay++;

            return delay;
        }

        private int CalculateSeverity(int delay)
        {
            int severity = 0;

            foreach (var firewall in firewalls)
            {
                if ((firewall.Depth + delay) % (2 * firewall.Range - 2) == 0)
                {
                    severity += (firewall.Depth * firewall.Range);
                    if (delay != 0) return 1;
                }
            }

            return severity;
        }
    }

    public class FireWall
    {
        public int Depth { get; }
        public int Range { get; }

        public FireWall(int depth, int range)
        {
            Depth = depth;
            Range = range;
        }
    }
}
