using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private readonly List<Racer> racers;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return racers.Count; } }
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            racers = new List<Racer>();
        }

        public void Add(Racer racer)
        {
            if (racers.Count < Capacity)
            {
                racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (racers.Any(racer => racer.Name == name))
            {
                for (int i = 0; i < racers.Count; i++)
                {
                    if (racers[i].Name == name)
                    {
                        racers.Remove(racers[i]);

                        return true;
                    }
                }
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer racer = racers.OrderByDescending(r => r.Age).FirstOrDefault();

            return racer;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = null;

            for (int i = 0; i < racers.Count; i++)
            {
                if (racers[i].Name == name)
                {
                    racer = racers[i];
                }
            }

            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer racer = racers.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

            return racer;
        }

        public string Report()
        {
            var result = new StringBuilder();

            result.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in racers)
            {
                result.AppendLine(racer.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
