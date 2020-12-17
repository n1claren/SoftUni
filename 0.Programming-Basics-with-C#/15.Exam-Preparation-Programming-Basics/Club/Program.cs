using System;

namespace Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double desiredIncome = double.Parse(Console.ReadLine());

            string cocktail = Console.ReadLine();
            int drinkPrice = 0;
            int drinks = 0;
            double drinksCost = 0.0;
            double totalIncome = 0.0;
            bool targetReached = false;


            while (cocktail != "Party!")
            {
                drinkPrice = cocktail.Length;
                drinks = int.Parse(Console.ReadLine());

                drinksCost = drinkPrice * drinks;

                if (drinksCost % 2 != 0)
                {
                    drinksCost -= drinksCost * 0.25;
                }

                totalIncome += drinksCost;
                drinksCost = 0;

                if (totalIncome >= desiredIncome)
                {
                    targetReached = true;
                    break;
                }

                cocktail = Console.ReadLine();
            }

           if (targetReached)
            {
                Console.WriteLine("Target acquired.");
                Console.WriteLine($"Club income - {totalIncome:F2} leva.");
            }
           else
            {
                Console.WriteLine($"We need {(desiredIncome - totalIncome):F2} leva more.");
                Console.WriteLine($"Club income - {totalIncome:F2} leva.");
            }
        }

    }
}
