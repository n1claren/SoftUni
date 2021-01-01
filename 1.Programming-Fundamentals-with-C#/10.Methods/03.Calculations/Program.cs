using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine().ToLower();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    AddNumbers(num1, num2);
                    break;
                case "subtract":
                    SubtractNumbers(num1, num2);
                    break;
                case "multiply":
                    MultiplyNumbers(num1, num2);
                    break;
                case "divide":
                    DivideNumbers(num1, num2);
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    break;
            }
        }

        static void AddNumbers(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static void SubtractNumbers(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }

        static void DivideNumbers(double num1, double num2)
        {
            Console.WriteLine(num1 / num2);
        }

        static void MultiplyNumbers(double num1, double num2)
        {
            Console.WriteLine(num1 * num2);
        }


    }
}