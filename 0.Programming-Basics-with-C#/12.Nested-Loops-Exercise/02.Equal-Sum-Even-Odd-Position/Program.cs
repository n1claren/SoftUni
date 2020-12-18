using System;

namespace EqualSumEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int leftNum = int.Parse(Console.ReadLine());
            int rightNum = int.Parse(Console.ReadLine());


            for (int i = leftNum; i <= rightNum; i++)
            {
                int oddSum = 0;
                int evenSum = 0;
                int number = i;

                for (int j = 6; j >= 1; j--)
                {
                    int a = number % 10;
                    number = number / 10;

                    if (j % 2 == 0)
                    {
                        evenSum += a;
                    }

                    else
                    {
                        oddSum += a;
                    }

                }

                if (oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
