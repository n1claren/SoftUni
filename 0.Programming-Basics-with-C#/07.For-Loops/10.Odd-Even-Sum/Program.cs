using System;
using System.Diagnostics.CodeAnalysis;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int even = 0;
            int odd = 0;

            for (int i = 1; i <= n; i++)
            {
                int add = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    even += add;
                }

                else
                {
                    odd += add;
                }
            }

            if (even == odd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {odd}");
            }

            else
            {
                Console.WriteLine("No");

                int diff = Math.Abs(even - odd);

                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
