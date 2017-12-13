using System;
using System.IO;

namespace AdventOfCode2017
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            Console.WriteLine(new Day13(input).Part1());
            Console.WriteLine(new Day13(input).Part2());
        }
    }
}
