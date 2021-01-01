using System;

namespace _11.Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            string operatorr = Console.ReadLine();
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculator(num1, operatorr, num2));
        }

        static double Calculator(double num1, string operatorr, double num2)
        {
            double result = 0;

            switch (operatorr)
            {
                case "/":
                    result = num1 / num2;
                    break;

                case "*":
                    result = num1 * num2;
                    break;

                case "-":
                    result = num1 - num2;
                    break;

                case "+":
                    result = num1 + num2;
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }

            return result;
        }
    }

}
