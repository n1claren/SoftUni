using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> quedNumbers = new Queue<int>(numbers);

            List<int> evenNumbers = new List<int>();

            while (quedNumbers.Count > 0)
            {
                int number = quedNumbers.Dequeue();

                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }

            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}
