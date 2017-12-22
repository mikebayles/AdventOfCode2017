using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public class Day20
    {
        private readonly List<Particle> particles;
        public Day20(string[] input)
        {
            particles = new List<Particle>();

            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var matches = Regex.Matches(line, @"-?\d+").Cast<Match>().Select(m => int.Parse(m.Value)).ToList();
                var p = new Particle();
                p.Id = i;
                p.Position = matches.Take(3).ToArray();
                p.Velocity = matches.Skip(3).Take(3).ToArray();
                p.Accel = matches.Skip(6).Take(3).ToArray();

                particles.Add(p);
            }
        }

        public void Part1()
        {
            while (true)
            {
                particles.ForEach(p => p.NextSecond());

                Console.WriteLine(particles.OrderBy(p => Math.Abs(p.AbsolutePosition)).First().Id);
            }
        }

        public int Part2()
        {
            while (true)
            {
                particles.ForEach(p => p.NextSecond());

                foreach (var particle in particles)
                {

                    var collision = particles.FirstOrDefault(p => p != particle && Enumerable.SequenceEqual(p.Position, particle.Position));
                    if (collision != null)
                    {
                        collision.Dead = true;
                        particle.Dead = true;
                    }
                }

                particles.RemoveAll(p => p.Dead);


                Console.WriteLine(particles.Count);
            }

            return 0;
        }
    }

    public class Particle
    {
        public int Id { get; set; }
        public int[] Position { get; set; }
        public int[] Velocity { get; set; }
        public int[] Accel { get; set; }
        public bool Dead { get; set; }

        public int AbsolutePosition => Position[0] + Position[1] + Position[2];

        public void NextSecond()
        {
            Velocity[0] += Accel[0];
            Velocity[1] += Accel[1];
            Velocity[2] += Accel[2];

            Position[0] += Velocity[0];
            Position[1] += Velocity[1];
            Position[2] += Velocity[2];
        }
    }
}
