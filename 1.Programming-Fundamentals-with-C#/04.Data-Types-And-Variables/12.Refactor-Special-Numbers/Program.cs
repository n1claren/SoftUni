using System;

namespace _12.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sum = 0;
                int current = i;
                bool state = false;

                while (current > 0)
                {
                    sum += current % 10;
                    current = current / 10;
                }

                state = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{i} -> {state}");

            }

        }
    }
}
