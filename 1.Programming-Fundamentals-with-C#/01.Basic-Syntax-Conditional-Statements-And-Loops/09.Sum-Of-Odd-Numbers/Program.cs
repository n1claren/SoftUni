using System;
using System.Diagnostics.Tracing;

namespace DivisibleBy3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    sum += i;
                    counter++;
                }

                if (counter == n)
                {
                    Console.WriteLine($"Sum: {sum}");
                    break;
                }
            }

        }
    }
}