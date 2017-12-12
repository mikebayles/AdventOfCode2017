using System.IO;
using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class Day11Test
    {
        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual(3, new Day11().Part1("ne,ne,ne"));
            Assert.AreEqual(0, new Day11().Part1("ne,ne,sw,sw"));
            Assert.AreEqual(2, new Day11().Part1("ne,ne,s,s"));
            Assert.AreEqual(3, new Day11().Part1("se,sw,se,sw,sw"));
            Assert.AreEqual(682, new Day11().Part1(File.ReadAllText("Day11.txt")));
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual(1406, new Day11().Part2(File.ReadAllText("Day11.txt")));
        }
    }
}
