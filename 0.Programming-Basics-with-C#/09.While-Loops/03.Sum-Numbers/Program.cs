using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num2 = 0;

            while (num > num2)
            {
                int num3 = int.Parse(Console.ReadLine());
                num2 += num3;
            }

            Console.WriteLine(num2);
        }
    }
}
