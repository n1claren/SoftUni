using System;

namespace _04.Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;

                for (int z = 2; z < i; z++)
                {
                    if (i % z == 0)
                    {
                        isPrime = false;

                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine($"{i} -> true");
                }
                else
                {
                    Console.WriteLine($"{i} -> false");
                }
            }

        }
    }
}
