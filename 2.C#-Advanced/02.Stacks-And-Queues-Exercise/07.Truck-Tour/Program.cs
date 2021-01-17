using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpCount = int.Parse(Console.ReadLine());

            Queue<string> gasPumps = new Queue<string>();

            for (int i = 0; i < pumpCount; i++)
            {
                string input = Console.ReadLine();

                input = input + $" {i}";

                gasPumps.Enqueue(input);
            }

            int currentGas = 0;

            for (int i = 0; i < pumpCount; i++)
            {
                string pumpInfo = gasPumps.Dequeue();

                string[] splittedInfo = pumpInfo.Split();

                int refill = int.Parse(splittedInfo[0]);
                int distance = int.Parse(splittedInfo[1]);
                int index = int.Parse(splittedInfo[2]);

                currentGas += refill;

                if (currentGas >= distance)
                {
                    currentGas -= distance;
                }    
                else
                {
                    currentGas = 0;
                    i = -1;
                }

                gasPumps.Enqueue(pumpInfo);
            }

            int result = gasPumps.Peek().Split().Select(int.Parse).Last();

            Console.WriteLine(result);
        }    
    }
}
