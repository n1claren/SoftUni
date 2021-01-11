using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Dragon_Army
{
    public class DragonArmy
    {
        public static void Main()
        {
            Dictionary<string, SortedDictionary<string, int[]>> dragons = new 
                Dictionary<string, SortedDictionary<string, int[]>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] newDragon = Console.ReadLine().Split();

                string type = newDragon[0];

                string name = newDragon[1];

                int damage = 0;
                int health = 0;
                int armor = 0;

                damage = newDragon[2] == "null" ? 45 : int.Parse(newDragon[2]);
                health = newDragon[3] == "null" ? 250 : int.Parse(newDragon[3]);
                armor = newDragon[4] == "null" ? 10 : int.Parse(newDragon[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, int[]>());
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type][name] = new int[3];
                }

                dragons[type][name][0] = damage;
                dragons[type][name][1] = health;
                dragons[type][name][2] = armor;
            }

            foreach (var dragon in dragons)
            {
                Console.WriteLine($"{dragon.Key}" +
                    $"::({dragon.Value.Select(x => x.Value[0]).Average():F}/{dragon.Value.Select(x => x.Value[1]).Average():f}" +
                    $"/{dragon.Value.Select(x => x.Value[2]).Average():f})");

                foreach (var item in dragon.Value)
                {
                    Console.WriteLine($"-{item.Key} -> " +
                        $"damage: {item.Value[0]}, " +
                        $"health: { item.Value[1]}, " +
                        $"armor: {item.Value[2]}");
                }
            }
        }
    }
}