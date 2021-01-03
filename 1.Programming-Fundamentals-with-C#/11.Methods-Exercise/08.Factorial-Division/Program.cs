using System;

namespace _08.Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInteger = int.Parse(Console.ReadLine());
            int secondInteger = int.Parse(Console.ReadLine());

            double factorialDivision = FactorialCalculator(firstInteger) /
                                       FactorialCalculator(secondInteger);

            Console.WriteLine($"{factorialDivision:F2}");
        }

        static double FactorialCalculator(int number)
        {
            double sum = 1;

            for (int i = number; i > 0; i--)
            {
                sum *= i;
            }

            return sum;
        }
    }
}
