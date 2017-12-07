using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day7
    {
        public string Part1(string[] input)
        {
            List<Tower> allTowers = new List<Tower>();
            foreach (var line in input)
            {
                var parts = line.Split();
                var tower = new Tower(parts[0], int.Parse(parts[1].Replace("(", "").Replace(")", "")));
                allTowers.Add(tower);
            }

            foreach (var line in input)
            {
                var parts = line.Split();
                var tower = allTowers.First(t => t.Name == parts[0]);
                foreach (var child in parts.Skip(3))
                {
                    tower.Children.Add(allTowers.First(t => t.Name == child.Replace(",", "")));
                }
            }

            string lowestTower = "";
            int maxDepth = 0;

            foreach (var tower in allTowers)
            {
                var currentDepth = Tower.CalculateDepth(tower);
                if (currentDepth > maxDepth)
                {
                    lowestTower = tower.Name;
                    maxDepth = currentDepth;
                }
            }

            return lowestTower;
        }

        public int Part2(string[] input)
        {
            List<Tower> allTowers = new List<Tower>();
            foreach (var line in input)
            {
                var parts = line.Split();
                var tower = new Tower(parts[0], int.Parse(parts[1].Replace("(", "").Replace(")", "")));
                allTowers.Add(tower);
            }

            foreach (var line in input)
            {
                var parts = line.Split();
                var tower = allTowers.First(t => t.Name == parts[0]);
                foreach (var child in parts.Skip(3))
                {
                    tower.Children.Add(allTowers.First(t => t.Name == child.Replace(",", "")));
                }
            }

            //answer from part 1
            var root = allTowers.First(t => t.Name == "airlri");
            int difference = 0;

            while (true)
            {
                var weights = new List<int>();
                foreach (var tower in allTowers.Where(t => t.Children.Count > 0 && t != root && root.Children.Contains(t)))
                {
                    var weight = Tower.CalculateWeight(tower);
                    weights.Add(weight);
                }

                if (weights.Count == 0)
                    break;

                var oddWeight = weights.GroupBy(i => i).OrderBy(grp => grp.Count())
                    .Select(grp => grp.Key).First();
                var normalWeight = weights.FirstOrDefault(a => a != oddWeight);

                if (normalWeight == default(int))
                    break;

                difference = Math.Abs(normalWeight - oddWeight);
                var worstTower = allTowers.First(t => t.FullWeight == oddWeight);
                root = worstTower;
            }


            return root.Weight - difference;
        }

        public class Tower
        {
            public string Name { get; }
            public int Weight { get; }
            public List<Tower> Children { get; }

            public Tower(string name, int weight)
            {
                Name = name;
                Weight = weight;
                Children = new List<Tower>();
            }

            public static int CalculateDepth(Tower tower)
            {
                int depth = 0;
                foreach (var child in tower.Children)
                {
                    depth = Math.Max(depth, 1 + CalculateDepth(child));
                }

                return depth;
            }

            public int FullWeight { get; private set; }

            public static int CalculateWeight(Tower tower)
            {
                int weight = tower.Weight;
                foreach (var child in tower.Children)
                {
                    weight += CalculateWeight(child);
                }

                tower.FullWeight = weight;
                return weight;
            }
        }
    }
}
