using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Fight
{
    class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= orcWaves; i++)
            {
                orcs = new Stack<int>(Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray());


                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());

                    plates.Add(newPlate);
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int currentOrc = orcs.Pop();
                    int currentPlate = plates[0];

                    if (currentOrc > currentPlate)
                    {
                        currentOrc -= currentPlate;

                        orcs.Push(currentOrc);

                        plates.RemoveAt(0);
                    }
                    else if (currentOrc < currentPlate)
                    {
                        currentPlate -= currentOrc;
                        plates[0] = currentPlate;
                    }
                    else
                    {
                        plates.RemoveAt(0);
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}