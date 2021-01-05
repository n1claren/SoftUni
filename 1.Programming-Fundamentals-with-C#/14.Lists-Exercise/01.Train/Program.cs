using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().ToLower().Split().ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int temp = 0;
                        temp = wagons[i] + int.Parse(command[0]);

                        if (temp > wagonCapacity)
                        {
                            continue;
                        }
                        else
                        {
                            wagons[i] = temp;
                            break;
                        }
                    }
                }

                command = Console.ReadLine().ToLower().Split().ToArray();
            }

            Console.WriteLine(string.Join(' ', wagons));

        }
    }
}
