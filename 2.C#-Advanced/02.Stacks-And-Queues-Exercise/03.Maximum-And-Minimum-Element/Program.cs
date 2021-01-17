using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_And_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < inputCount; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (input[0] == 2)
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }

                if (input[0] == 3)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }

                if (input[0] == 4)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }

                if (input[0] == 1)
                {
                    numbers.Push(input[1]);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
