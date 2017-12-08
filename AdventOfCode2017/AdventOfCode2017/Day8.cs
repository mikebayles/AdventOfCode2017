using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day8
    {
        public int Part1(string[] input)
        {
            return CalculateMax(input, false);
        }

        public int Part2(string[] input)
        {
            return CalculateMax(input, true);
        }

        private int CalculateMax(string[] input, bool maxEver)
        {
            Dictionary<string, int> registers = new Dictionary<string, int>();
            int max = 0;

            foreach (var line in input)
            {
                var parts = line.Split();
                if (!registers.ContainsKey(parts[0]))
                {
                    registers[parts[0]] = 0;
                }

                var registerToModify = registers[parts[0]];
                var instruction = parts[1];
                var value = int.Parse(parts[2]);

                if (!registers.ContainsKey(parts[4]))
                {
                    registers[parts[4]] = 0;
                }

                var registerToCompare = registers[parts[4]];
                var comparisonInstruction = parts[5];
                var comparisonValue = int.Parse(parts[6]);

                if (ApplyComparison(registerToCompare, comparisonInstruction, comparisonValue))
                {
                    registers[parts[0]] = registerToModify + (instruction == "inc" ? value : (-1 * value));
                }

                max = Math.Max(max, registers.Max(a => a.Value));
            }

            return maxEver ? max : registers.Max(a => a.Value);
        }

        private bool ApplyComparison(int startingValue, string comparisonInstruction, int comparisonValue)
        {
            switch (comparisonInstruction)
            {
                case ">":
                    return startingValue > comparisonValue;
                case ">=":
                    return startingValue >= comparisonValue;
                case "<":
                    return startingValue < comparisonValue;
                case "<=":
                    return startingValue <= comparisonValue;
                case "==":
                    return startingValue == comparisonValue;
                case "!=":
                    return startingValue != comparisonValue;
                default:
                    throw new Exception("Unexpected instruction " + comparisonInstruction);
            }
        }
    }
}
