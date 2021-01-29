using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersRange = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 1; i <= numbersRange; i++)
            {
                numbers.Add(i);
            }

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<List<int>, int[], List<int>> filtration = new Func<List<int>, int[], List<int>>
                ((numbers, dividers) =>
                {
                    return numbers.Where(n => DevidersInfo(n, dividers)).ToList();
                });

            Action<List<int>> print = new Action<List<int>>(list =>
            {
                Console.WriteLine(string.Join(' ', list));
            });

            numbers = filtration(numbers, dividers);
            print(numbers);
        }

        private static bool DevidersInfo(int n, int[] dividers)
        {
            bool isTrue = true;
            foreach (int divider in dividers)
            {
                if (n % divider != 0)
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }
    }
}
    

