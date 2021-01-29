using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> remover = new Func<List<int>, List<int>>(list =>
            {
                return list.Where(n => n % divider != 0).Reverse().ToList();
            });

            Action<List<int>> print = new Action<List<int>>(list =>
            {
                Console.WriteLine(string.Join(' ', list));
            });

            collection = remover(collection);
            print(collection);
        }
    }
}
