using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int a = 0; a <= n; a++)
            {
                for (int b = 0; b <= n; b++)
                {
                    for (int c = 0; c <= n; c++)
                    {
                        if (a + b + c == n)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
