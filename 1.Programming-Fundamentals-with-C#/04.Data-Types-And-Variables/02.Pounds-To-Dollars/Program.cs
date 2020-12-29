using System;

namespace _02.Pounds_To_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal britishPounds = decimal.Parse(Console.ReadLine());

            decimal unitedStatesDollars = britishPounds * (decimal)1.31;

            Console.WriteLine($"{unitedStatesDollars:F3}");
        }
    }
}
