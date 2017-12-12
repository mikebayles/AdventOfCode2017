using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day12
    {
        public int Part1(string[] input)
        {
            return Calculate(input, true);
        }

        public int Part2(string[] input)
        {
            return Calculate(input, false);
        }

        private int Calculate(string[] input, bool part1)
        {
            List<Node> nodes = new List<Node>();

            foreach (var line in input)
            {
                var parts = line.Split();
                var id = int.Parse(parts[0]);
                var destinations = string.Join("", parts.Skip(2).ToArray()).Split(',').Select(a => int.Parse(a)).ToList();

                Node rootNode = nodes.FirstOrDefault(a => a.Id == id);
                if (rootNode == null)
                {
                    rootNode = new Node(id);
                    nodes.Add(rootNode);
                }

                foreach (var destination in destinations)
                {
                    Node destinatioNode = nodes.FirstOrDefault(a => a.Id == destination);
                    if (destinatioNode == null)
                    {
                        destinatioNode = new Node(destination);
                        nodes.Add(destinatioNode);
                    }

                    rootNode.Destinations.Add(destinatioNode);
                }
            }

            int groupCount = 0;
            while (nodes.Count > 0)
            {
                var group1 = Node.AllDestinations(new HashSet<Node>(), nodes[0]);

                if (part1) return group1.Count;

                nodes.RemoveAll(a => group1.Contains(a));
                groupCount++;
            }

            return groupCount;
        }
    }

    public class Node
    {
        public int Id { get; }
        public List<Node> Destinations { get; }

        public Node(int source)
        {
            Id = source;
            Destinations = new List<Node>();
        }

        public static List<Node> AllDestinations(HashSet<Node> seen, Node start)
        {
            foreach (var dest in start.Destinations)
            {
                if (!seen.Add(dest))
                    continue;

                seen.Union(AllDestinations(seen, dest));
            }

            return seen.ToList();
        }
    }
}
