using System;

namespace _08.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(MathPower(number, power));
        }

        static double MathPower(double num, double power)
        {
            return Math.Pow(num, power);
        }
    }
}