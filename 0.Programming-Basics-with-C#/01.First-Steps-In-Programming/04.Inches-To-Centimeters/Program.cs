using System;
using System.Dynamic;

namespace InchToCm
{
    class Program
    {
        static void Main(string[] args)
        {
            String imput = Console.ReadLine();
            double centimeters = double.Parse(imput);

            double inches = centimeters * 2.54;
            Console.WriteLine(inches);

        }
    }
}
