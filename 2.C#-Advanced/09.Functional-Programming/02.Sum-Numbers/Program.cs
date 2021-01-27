using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = int.Parse;

            List<int> numbers = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
