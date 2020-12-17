using System;

namespace CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Monday Tuesday Wednesday Thursday  Friday  Saturday  Sunday
            //12      12       14        14        12      16        16

            string dayOfWeek = Console.ReadLine();
            double ticketPrice = 0.0;

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    ticketPrice = 12;
                    break;
                case "Wednesday":
                case "Thursday":
                    ticketPrice = 14;
                    break;
                case "Saturday":
                case "Sunday":
                    ticketPrice = 16;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;

                   
            }

            Console.WriteLine(ticketPrice);

        }
    }
}
