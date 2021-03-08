using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(8);
            Rectangle rectangle = new Rectangle(12, 8);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
