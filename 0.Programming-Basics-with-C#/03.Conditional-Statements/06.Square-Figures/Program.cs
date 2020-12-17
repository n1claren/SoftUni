using System;

namespace SquareFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double cm2 = side * side;
                Console.WriteLine(cm2);
            }
            else if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double cm2 = sideA * sideB;
                Console.WriteLine(cm2);
            }
            else if (figure == "circle")
            { double radius = double.Parse(Console.ReadLine());
                double cm2 = Math.PI * (radius * radius);
                Console.WriteLine(cm2);
            }
            else if (figure == "triangle")
            { double sideA = double.Parse(Console.ReadLine());
                double sideAHeight = double.Parse(Console.ReadLine());
                double cm2 = (sideA * sideAHeight) / 2;
                Console.WriteLine(cm2);
            }
        }
    }
}
