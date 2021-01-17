using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int pushElements = input[0];
            int popElements = input[1];
            int containsElement = input[2];

            int[] stackInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> elements = new Stack<int>(stackInput);

            //for (int i = 0; i < pushElements; i++)
            //{
            //    elements.Push(1);
            //}

            for (int i = 0; i < popElements; i++)
            {
                elements.Pop();
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
