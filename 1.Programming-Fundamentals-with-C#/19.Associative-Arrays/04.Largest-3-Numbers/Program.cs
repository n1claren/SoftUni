using System;
using System.Linq;

namespace _04.Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sortedNumbers = numbers.OrderByDescending(n => n).ToArray();

            if (sortedNumbers.Length < 3)
            {
                for (int i = 0; i < sortedNumbers.Length; i++)
                {
                    Console.Write(sortedNumbers[i] + " ");
                }
            }

            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(sortedNumbers[i] + " ");
                }
            }
        }
    }
}