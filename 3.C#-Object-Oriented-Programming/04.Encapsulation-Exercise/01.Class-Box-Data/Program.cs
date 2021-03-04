using System;

namespace _01.Class_Box_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box boxyBox = new Box(length, width, height);

                boxyBox.PrintSurfaceArea();
                boxyBox.PrintLateralSurfaceArea();
                boxyBox.PrintVolume();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
