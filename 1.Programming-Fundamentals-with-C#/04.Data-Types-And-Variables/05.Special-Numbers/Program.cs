using System;

namespace _05.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int numberSum = 0;

                while (number > 0)
                {
                    int addition = number % 10;

                    numberSum += addition;

                    number = number / 10;
                }

                if (numberSum == 5 || numberSum == 7 || numberSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
