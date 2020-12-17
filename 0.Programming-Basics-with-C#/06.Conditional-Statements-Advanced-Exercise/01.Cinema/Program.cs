using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int seats = rows * columns;
            double ticketPrice = 0.0;

            if (projectionType == "Premiere")
            {
                ticketPrice = 12.00;
            }
            else if (projectionType == "Normal")
            {
                ticketPrice = 7.50;
            }
            else if (projectionType == "Discount")
            {
                ticketPrice = 5.00;
            }

            double revenue = seats * ticketPrice;

            Console.WriteLine($"{revenue:F2}");
        }
    }
}
