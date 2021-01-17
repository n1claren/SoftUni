using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

            int[] inputQueue = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

            Queue<int> elements = new Queue<int>(inputQueue);

            int addElements = input[0];
            int removeElements = input[1];
            int containsElement = input[2];

            //for (int i = 0; i < addElements; i++)
            //{
            //    elements.Enqueue(1);
            //}

            for (int i = 0; i < removeElements; i++)
            {
                elements.Dequeue();
            }

            if (elements.Contains(containsElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (elements.Count > 0)
                {
                    Console.WriteLine(elements.Min());
                }
                else
                { 
                    Console.WriteLine(0);
                }
            }
        }
    }
}
