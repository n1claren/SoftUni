using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|")
                .ToList();

            input.Reverse();

            List<int> result = new List<int>();

            foreach (string item in input)
            {
                string[] numbers = item
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var number in numbers)
                {
                    result.Add(int.Parse(number));
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
