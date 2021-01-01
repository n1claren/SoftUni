using System;

namespace _02.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = 1;

                for (int z = 0; z <= i; z++)
                {
                    Console.Write($"{number} ");

                    number = number * (i - z) / (z + 1);
                }

                Console.WriteLine();
            }
        }
    }
}
