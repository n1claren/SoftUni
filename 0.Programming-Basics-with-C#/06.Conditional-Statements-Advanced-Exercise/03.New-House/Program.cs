using System;

namespace NewHome2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double flowerPrice = 0.0;

            if (flowerType == "Roses")
            {
                flowerPrice = 5.00;

                if (flowerCount > 80)
                {
                    flowerPrice = flowerPrice - (flowerPrice * 0.10);
                }    
            }

            else if (flowerType == "Dahlias")
            {
                flowerPrice = 3.80;

                if (flowerCount > 90)
                {
                    flowerPrice = flowerPrice - (flowerPrice * 0.15);
                }
            }

            else if (flowerType == "Tulips")
            {
                flowerPrice = 2.80;

                if (flowerCount > 80)
                {
                    flowerPrice = flowerPrice - (flowerPrice * 0.15);
                }
            }
            
            else if (flowerType == "Narcissus")
            {
                flowerPrice = 3.00;

                if (flowerCount < 120)
                {
                    flowerPrice = flowerPrice + (flowerPrice * 0.15);
                }
            }

            else if (flowerType == "Gladiolus")
            {
                flowerPrice = 2.50;

                if (flowerCount < 80)
                {
                    flowerPrice = flowerPrice + (flowerPrice * 0.2);
                }
            }

            double cost = flowerPrice * flowerCount;

            if (cost > budget)
            {
                double moneyNeeded = cost - budget;

                Console.WriteLine($"Not enough money, you need {moneyNeeded:F2} leva more.");
            }
            else
            {
                double moneyLeft = budget - cost;

                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {moneyLeft:F2} leva left.");
            }
        }

    }
}
