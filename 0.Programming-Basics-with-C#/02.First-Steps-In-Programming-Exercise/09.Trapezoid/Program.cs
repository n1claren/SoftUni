using System;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double cm2 = ((b1 + b2) * h) / 2;
            Console.WriteLine($"{cm2:f2}");

        }
    }
}
