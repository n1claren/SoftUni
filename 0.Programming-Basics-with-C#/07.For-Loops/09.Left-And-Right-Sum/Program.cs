using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int left = 0;
            int right = 0;

            for (int i = 0; i < n; i++)
            {
                int add = int.Parse(Console.ReadLine());
                left += add;
            }

            for (int i = 0; i < n; i++)
            {
                int add = int.Parse(Console.ReadLine());
                right += add;
            }

           if (left == right)
            {
                Console.WriteLine($"Yes, sum = {left}");
            }

           else
            {
                int difference = Math.Abs(left - right);

                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
