using System;

namespace _03.Exact_Sum_Of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal result = 0M;

            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());

                result += number;
            }

            Console.WriteLine(result);
        }
    }
}
