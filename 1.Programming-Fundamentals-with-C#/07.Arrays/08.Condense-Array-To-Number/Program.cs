using System;
using System.Linq;

namespace _08.Condense_Array_To_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToArray();

            while (numbers.Length != 1)
            {
                int[] condenced = new int[numbers.Length - 1];

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    condenced[i] = numbers[i] + numbers[i + 1];
                }

                numbers = condenced;
            }

            Console.WriteLine(numbers[0]);
        }
    }
}
