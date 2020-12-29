using System;

namespace _01.Convert_Meters_To_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());

            decimal km = number / 1000;

            Console.WriteLine($"{km:F2}");
        }

    }
}
