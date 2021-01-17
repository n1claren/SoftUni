using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothesBox = new Stack<int>(input);

            int currentRack = rackCapacity;
            int racksUsed = 1;

            while (clothesBox.Count > 0)
            {
                int currentCloth = clothesBox.Pop();

                if (currentRack - currentCloth >= 0)
                {
                    currentRack -= currentCloth;
                }
                else
                {
                    currentRack = rackCapacity;
                    racksUsed++;
                    currentRack -= currentCloth;
                }
                
            }

            Console.WriteLine(racksUsed);
        }
    }
}
