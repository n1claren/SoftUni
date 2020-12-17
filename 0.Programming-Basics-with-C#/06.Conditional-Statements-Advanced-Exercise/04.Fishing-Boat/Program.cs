using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double shipRent = 0.0;
            double discount = 0.0;

            switch (season)

            {
                case "Spring":

                    shipRent = 3000.00;
                    break;

                case "Summer":
                case "Autumn":

                    shipRent = 4200.00;
                    break;

                case "Winter":

                    shipRent = 2600.00;
                    break;
            }


            if (fishermen <= 6)
            {
                discount = 0.1;
            }

            else if (fishermen >= 7 && fishermen <= 11)
            {
                discount = 0.15;
            }

            else if (fishermen >= 12)
            {
                discount = 0.25;
            }

            double shipRentD1 = shipRent - (shipRent * discount);
            double shipRebtD2 = 0.0;

            if (fishermen %2 == 0 && season != "Autumn")
            {
                shipRebtD2 = shipRentD1 - (shipRentD1 * 0.05);
            } 
            else
            {
                shipRebtD2 = shipRentD1;
            }

            if (budget >= shipRebtD2)
            {
                double moneyLeft = budget - shipRebtD2;

                Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
            }
            else if (budget < shipRebtD2)
            {
                double moneyNeeded = shipRebtD2 - budget;

                Console.WriteLine($"Not enough money! You need {moneyNeeded:F2} leva.");
            }
        }
    }
}
