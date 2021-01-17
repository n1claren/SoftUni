using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Cups_And_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cups = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            List<int> bottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Stack<int> cupsStack = new Stack<int>(cups);

            Stack<int> bottlesStack = new Stack<int>(bottles);

            var wastedWater = 0;

            while (cupsStack.Count != 0 && bottlesStack.Count != 0)
            {
                int bottleSize = bottlesStack.Pop();

                int cupSize = cupsStack.Pop();

                if (cupSize > bottleSize)
                {
                    int fillUp = cupSize - bottleSize;

                    cupsStack.Push(fillUp);
                }
                else
                {
                    wastedWater += bottleSize - cupSize;
                }
            }

            if (bottlesStack.Count != 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {

                Console.WriteLine($"Cups: {string.Join(" ", cupsStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }

        }
    }
}