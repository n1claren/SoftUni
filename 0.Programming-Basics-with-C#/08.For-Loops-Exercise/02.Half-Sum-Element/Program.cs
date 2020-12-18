using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            int maxValue = int.MinValue;

            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                
                if (num > maxValue)
                {
                    maxValue = num;
                }

                sum += num;
            }

            if (sum - maxValue == maxValue)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxValue}");
            }

            else
            {
                int diff = Math.Abs(maxValue - (sum - maxValue));
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }

        }
    }
}
