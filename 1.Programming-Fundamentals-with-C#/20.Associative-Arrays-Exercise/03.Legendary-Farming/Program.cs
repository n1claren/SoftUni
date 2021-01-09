using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split();

            int shards = 0;
            int fragments = 0;
            int motes = 0;

            Dictionary<string, int> importantMaterials = new Dictionary<string, int>();
            Dictionary<string, int> unimportantMaterials = new Dictionary<string, int>();

            importantMaterials.Add("fragments", 0);
            importantMaterials.Add("shards", 0);
            importantMaterials.Add("motes", 0);

            while (shards < 250 && fragments < 250 && motes < 250)
            {
                for (int i = 1; i < input.Length; i += 2)
                {
                    switch (input[i])
                    {
                        case "shards":
                            if (importantMaterials.ContainsKey("shards"))
                            {
                                importantMaterials["shards"] += int.Parse(input[i - 1]);
                            }
                            else
                            {
                                importantMaterials.Add("shards", int.Parse(input[i - 1]));
                            }

                            shards += int.Parse(input[i - 1]);

                            break;

                        case "fragments":
                            if (importantMaterials.ContainsKey("fragments"))
                            {
                                importantMaterials["fragments"] += int.Parse(input[i - 1]);
                            }
                            else
                            {
                                importantMaterials.Add("fragments", int.Parse(input[i - 1]));
                            }

                            fragments += int.Parse(input[i - 1]);

                            break;

                        case "motes":
                            if (importantMaterials.ContainsKey("motes"))
                            {
                                importantMaterials["motes"] += int.Parse(input[i - 1]);
                            }
                            else
                            {
                                importantMaterials.Add("motes", int.Parse(input[i - 1]));
                            }

                            motes += int.Parse(input[i - 1]);

                            break;

                        default:

                            if (unimportantMaterials.ContainsKey(input[i]))
                            {
                                unimportantMaterials[input[i]] += int.Parse(input[i - 1]);
                            }
                            else
                            {
                                unimportantMaterials.Add(input[i], int.Parse(input[i - 1]));
                            }
                            break;
                    }

                    if (shards >= 250 || fragments >= 250 || motes >= 250)
                    {
                        break;
                    }
                }

                if (shards >= 250 || fragments >= 250 || motes >= 250)
                {
                    break;
                }

                input = Console.ReadLine().ToLower().Split();
            }

            if (shards >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");

                importantMaterials["shards"] -= 250;
            }

            if (fragments >= 250)
            {
                Console.WriteLine("Valanyr obtained!");

                importantMaterials["fragments"] -= 250;
            }

            if (motes >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");

                importantMaterials["motes"] -= 250;
            }

            var importantMaterialsSorted = importantMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            var junkMaterialsSorted = unimportantMaterials.OrderBy(x => x.Key);

            foreach (var material in importantMaterialsSorted)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junkMaterialsSorted)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
