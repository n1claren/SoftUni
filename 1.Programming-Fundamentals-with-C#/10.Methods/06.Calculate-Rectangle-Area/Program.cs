using System;

namespace _06.Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());

            Console.WriteLine(CalculateRectangleArea(height, lenght));
        }

        static double CalculateRectangleArea(double height, double lenght)
        {
            return height * lenght;
        }
    }
}
