using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysStay = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string satisfaction = Console.ReadLine();

            double rentPerNight = 0.0;
            double discount = 0.0;
            

            int nightsStay = daysStay - 1;

            switch (roomType)
            {
                case "room for one person":
                    
                    if (nightsStay < 10)
                    {
                        discount = 0.0;
                        rentPerNight = 18.00;
                    }  
                    else if (nightsStay >= 10 && nightsStay <= 15)
                    {
                        discount = 0.0;
                        rentPerNight = 18.00;
                    }
                    else if (nightsStay > 15)
                    {
                        discount = 0.0;
                        rentPerNight = 18.00;
                    }
                    break;

                case "apartment":

                    if (nightsStay < 10)
                    {
                        discount = 0.3;
                        rentPerNight = 25.00;
                    }
                    else if (nightsStay >= 10 && nightsStay <= 15)
                    {
                        discount = 0.35;
                        rentPerNight = 25.00;
                    }
                    else if (nightsStay > 15)
                    {
                        discount = 0.5;
                        rentPerNight = 25.00;
                    }
                    break;

                case "president apartment":

                    if (nightsStay < 10)
                    {
                        discount = 0.1;
                        rentPerNight = 35.00;
                    }
                    else if (nightsStay >= 10 && nightsStay <= 15)
                    {
                        discount = 0.15;
                        rentPerNight = 35.00;
                    }
                    else if (nightsStay > 15)
                    {
                        discount = 0.2;
                        rentPerNight = 35.00;
                    }
                    break;

            }

            double rent = (rentPerNight * nightsStay) - (rentPerNight * nightsStay * discount);

            double finalrent = 0.0;

            if (satisfaction == "positive")
            {
                finalrent = rent + (rent * 0.25);
            }
            else if (satisfaction == "negative")
            {
                finalrent = rent - (rent * 0.1);
            }

            Console.WriteLine($"{finalrent:F2}");

        }
    }
}
