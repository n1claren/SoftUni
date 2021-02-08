using System;
using System.Collections.Generic;
using System.Linq;

namespace tralala
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> inputs = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                inputs.Add(input);
            }

            Box<int> box = new Box<int>(inputs);

            int[] swapIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = swapIndexes[0];
            int secondIndex = swapIndexes[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box.ToString());
        }
    }
}
