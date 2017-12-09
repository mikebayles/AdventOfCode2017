using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class Day9Test
    {
        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual(1, new Day9().Part1("{}"));
            Assert.AreEqual(6, new Day9().Part1("{{{}}}"));
            Assert.AreEqual(5, new Day9().Part1("{{},{}}"));
            Assert.AreEqual(16, new Day9().Part1("{{{},{},{{}}}}"));
            Assert.AreEqual(1, new Day9().Part1("{<a>,<a>,<a>,<a>}"));
            Assert.AreEqual(9, new Day9().Part1("{{<ab>},{<ab>},{<ab>},{<ab>}}"));
            Assert.AreEqual(9, new Day9().Part1("{{<!!>},{<!!>},{<!!>},{<!!>}}"));
            Assert.AreEqual(3, new Day9().Part1("{{<a!>},{<a!>},{<a!>},{<ab>}}"));
            Assert.AreEqual(16021, new Day9().Part1(File.ReadAllText("Day9.txt")));

        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual(0, new Day9().Part2("<>"));
            Assert.AreEqual(17, new Day9().Part2("<random characters>"));
            Assert.AreEqual(3, new Day9().Part2("<<<<>"));
            Assert.AreEqual(2, new Day9().Part2("<{!>}>"));
            Assert.AreEqual(0, new Day9().Part2("<!!>"));
            Assert.AreEqual(0, new Day9().Part2("<!!!>>"));
            Assert.AreEqual(10, new Day9().Part2("<{o\"i!a,<{i<a>"));
            Assert.AreEqual(7685, new Day9().Part2(File.ReadAllText("Day9.txt")));
        }
    }
}
