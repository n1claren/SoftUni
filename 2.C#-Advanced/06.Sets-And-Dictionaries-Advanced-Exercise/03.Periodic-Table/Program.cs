using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> uniqueElements = new SortedSet<string>();

            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                string[] elements = Console.ReadLine().Split();

                foreach (var element in elements)
                {
                    uniqueElements.Add(element);
                }
            }

            foreach (var element in uniqueElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
