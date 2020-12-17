using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double overnightStudio = 0.0;
            double overnightApartment = 0.0;

            if (month == "May" || month == "October")
            {
                overnightApartment = 65;
                overnightStudio = 50;

                if (nights > 7 && nights <= 14) 
                {
                    overnightStudio = overnightStudio - overnightStudio * 0.05;
                }
                else if (nights > 14)
                {
                    overnightStudio = overnightStudio - overnightStudio * 0.3;
                    overnightApartment = overnightApartment - overnightApartment * 0.1;
                }
            }

            if (month == "June" || month == "September")
            {
                overnightStudio = 75.20;
                overnightApartment = 68.70;

                if (nights > 14)
                {
                    overnightApartment = overnightApartment - overnightApartment * 0.1;
                    overnightStudio = overnightStudio - overnightStudio * 0.2;
                }
            }

            if (month == "July" || month == "August")
            {
                overnightApartment = 77;
                overnightStudio = 76;

                if (nights > 14)
                {
                    overnightApartment = overnightApartment - overnightApartment * 0.1;
                }
            }

            double priceApartment = nights * overnightApartment;
            double priceStudio = nights * overnightStudio;

            Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");

        }
    }
}
