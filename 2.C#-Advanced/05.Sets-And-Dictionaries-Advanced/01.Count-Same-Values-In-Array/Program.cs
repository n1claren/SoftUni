using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Count_Same_Values_In_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numbersCount = new Dictionary<double, int>();

            foreach (var number in input)
            {
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }

                numbersCount[number]++;
            }

            foreach (var kvp in numbersCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
