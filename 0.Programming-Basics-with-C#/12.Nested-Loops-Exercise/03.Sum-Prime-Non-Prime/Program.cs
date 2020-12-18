using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int primeSum = 0;
            int nonPrimeSum = 0;
            bool nonPrime = false;

            while (input != "stop")
            {
                int num = int.Parse(input);

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");

                    input = Console.ReadLine();

                    continue;
                }

                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        nonPrime = true;
                        break;
                    }

                }

                if (nonPrime && num != 1)
                {
                    nonPrimeSum += num;
                    nonPrime = false;
                }

                else
                {
                    primeSum += num;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");

        }
    }
}
