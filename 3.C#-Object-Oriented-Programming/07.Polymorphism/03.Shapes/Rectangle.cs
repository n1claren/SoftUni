using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (height + width);
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    sb.Append("*");
                }

                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
