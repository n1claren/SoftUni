using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drinkType = Console.ReadLine();
            string sugar = Console.ReadLine();
            int drinks = int.Parse(Console.ReadLine());

            double drinkPrice = 0.0;

            switch (drinkType)
            {
                case "Espresso":
                    if (sugar == "Without")
                    {
                        drinkPrice = 0.9;
                    }
                    else if (sugar == "Normal")
                    {
                        drinkPrice = 1;
                    }
                    else if (sugar == "Extra")
                    {
                        drinkPrice = 1.2;
                    }
                    break;
                case "Cappuccino":
                    if (sugar == "Without")
                    {
                        drinkPrice = 1;
                    }
                    else if (sugar == "Normal")
                    {
                        drinkPrice = 1.2;
                    }
                    else if (sugar == "Extra")
                    {
                        drinkPrice = 1.6;
                    }
                    break;
                case "Tea":
                    if (sugar == "Without")
                    {
                        drinkPrice = 0.5;
                    }
                    else if (sugar == "Normal")
                    {
                        drinkPrice = 0.6;
                    }
                    else if (sugar == "Extra")
                    {
                        drinkPrice = 0.7;
                    }
                    break;
            }

            double drinksCost = drinks * drinkPrice;

            if (sugar == "Without")
            {
                drinksCost -= drinksCost * 0.35;
            }

            if (drinkType == "Espresso" & drinks >= 5)
            {
                drinksCost -= drinksCost * 0.25;
            }

            if (drinksCost > 15)
            {
                drinksCost -= drinksCost * 0.2;
            }

            Console.WriteLine($"You bought {drinks} cups of {drinkType} for {drinksCost:F2} lv.");
        }
    }
}
