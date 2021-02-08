using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Generic_Swap_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> inputs = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                inputs.Add(input);
            }

            Box<string> box = new Box<string>(inputs);

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
