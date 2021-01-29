using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Action<List<int>> print = new Action<List<int>>(list =>
           {
               Console.WriteLine(string.Join(' ', list));
           });

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<List<int>, List<int>> processor = GetProccessor(input);

                    numbers = processor(numbers);
                }

                input = Console.ReadLine();
            }
        }

        static Func<List<int>, List<int>> GetProccessor(string input)
        {
            Func<List<int>, List<int>> processor = null;

            if (input == "add")
            {
                processor = new Func<List<int>, List<int>>(list =>
                {
                    return list.Select(n => n + 1).ToList();
                });
            }
            else if (input == "multiply")
            {
                processor = new Func<List<int>, List<int>>(list =>
                {
                    return list.Select(n => n *= 2).ToList();
                });
            }
            else if (input == "subtract")
            {
                processor = new Func<List<int>, List<int>>(list =>
                {
                    return list.Select(n => n - 1).ToList();
                });
            }

            return processor;
        }
    }
}
