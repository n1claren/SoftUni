using System;
using System.Linq;

namespace _02.From_Left_To_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split();

                long leftNum = long.Parse(numbers[0]);
                long rightNum = long.Parse(numbers[1]);

                long biggerNumber = rightNum;

                if (leftNum > rightNum)
                {
                    biggerNumber = leftNum;
                }

                long result = 0;

                while (biggerNumber != 0)
                {
                    result += biggerNumber % 10;
                    biggerNumber /= 10;
                }

                Console.WriteLine(Math.Abs(result));
            }
        }
    }
}
