using System;

namespace _07.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int tankCapacity = 255;
            int tankLiters = 0;

            for (int i = 1; i <= n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input > tankCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    tankCapacity -= input;
                    tankLiters += input;
                }
            }

            Console.WriteLine(tankLiters);
        }
    }
}
