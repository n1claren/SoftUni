using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Class_Box_Data
{
    public class Box
    {
        private const string ERROR_MESSAGE = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get { return this.length; }

            private set
            {
                ValidateInputValue(value, nameof(Lenght));

                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }

            private set
            {
                ValidateInputValue(value, nameof(Width));

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }

            private set
            {
                ValidateInputValue(value, nameof(Height));

                this.height = value;
            }
        }

        private static void ValidateInputValue(double value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(String.Format(ERROR_MESSAGE, paramName));
            }
        }

        public void PrintLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;

            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
        }

        public void PrintSurfaceArea()
        {
            double surfaceArea = 2 * this.Lenght * this.Width 
                                + 2 * this.Lenght * this.Height 
                                + 2 * this.Width * this.Height;

            Console.WriteLine($"Surface Area - {surfaceArea:F2}");
        }

        public void PrintVolume()
        {
            double volume = this.Height * this.Width * this.Lenght;

            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}
