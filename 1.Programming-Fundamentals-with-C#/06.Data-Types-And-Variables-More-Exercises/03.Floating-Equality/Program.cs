using System;

namespace _03.Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;
            double numberOne = 0.0;
            double numberTwo = 0.0;

            while (true)
            {
                numberOne = double.Parse(Console.ReadLine());
                numberTwo = double.Parse(Console.ReadLine());
                bool isEqual = Math.Abs(numberOne - numberTwo) < eps;


                if (isEqual)
                {
                    Console.WriteLine("True");

                    return;
                }
                else
                {
                    Console.WriteLine("False");

                    return;
                }
            }
        }
    }
}
