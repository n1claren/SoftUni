using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setLenghts = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            HashSet<int> first = new HashSet<int>(setLenghts[0]);
            HashSet<int> second = new HashSet<int>(setLenghts[1]);

            for (int i = 0; i < setLenghts[0]; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setLenghts[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var number in first)
            {
                if (second.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
