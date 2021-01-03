using System;

namespace _05.Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());
            double numberThree = double.Parse(Console.ReadLine());

            double result = numberOne * numberTwo * numberThree;

            Console.WriteLine(GetPolarity(result));
        }

        static string GetPolarity(double number)
        {
            if (number > 0)
            {
                return "positive";
            }
            else if (number < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }
    }
}
