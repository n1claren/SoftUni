using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int o = 1; o <= 9; o++)
                {
                    for (int p = 1; p <= 9; p++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            if (n % i == 0 && n % o == 0 && n % p == 0 && n % l == 0)
                            {
                                Console.Write($"{i}{o}{p}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
