using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                var inputs = input.Split(" <:> ").ToList();

                string name = inputs[0];

                string color = inputs[1];

                int physics = int.Parse(inputs[2]);

                string ID = $"{name}:{color}";

                if (!dwarfs.ContainsKey(ID))
                {
                    dwarfs.Add(ID, physics);
                }
                else
                {
                    dwarfs[ID] = Math.Max(dwarfs[ID], physics);
                }

            }

            foreach (var dwarf in dwarfs
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfs.Where(y => y.Key.Split(":")[0] == y.Key.Split(":")[0])
                                             .Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split(":")[1]}) {dwarf.Key.Split(":")[0]} <-> {dwarf.Value}");
            }
        }
    }
}