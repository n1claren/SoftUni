using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int heroesNeeded = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count < heroesNeeded)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Paladin":
                        Paladin paladin = new Paladin(heroName);
                        heroes.Add(paladin);
                        break;

                    case "Druid":
                        Druid druid = new Druid(heroName);
                        heroes.Add(druid);
                        break;

                    case "Warrior":
                        Warrior warrior = new Warrior(heroName);
                        heroes.Add(warrior);
                        break;

                    case "Rogue":
                        Rogue rogue = new Rogue(heroName);
                        heroes.Add(rogue);
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            int bossHealth = int.Parse(Console.ReadLine());

            int squadPower = 0;

            foreach (BaseHero hero in heroes)
            {
                squadPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (squadPower >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
