using System;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
