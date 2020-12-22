using System;
using System.Runtime.InteropServices.ComTypes;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string insertedCoin = Console.ReadLine();

            double coinSum = 0.0;

            while (insertedCoin != "Start")
            {
                double coinValue = double.Parse(insertedCoin);

                if (coinValue == 0.1 || coinValue == 0.2 || coinValue == 0.5 || coinValue == 1 || coinValue == 2)
                {
                    coinSum += coinValue;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coinValue}");
                }

                insertedCoin = Console.ReadLine();
            }

            string food = Console.ReadLine().ToLower();

            double foodPrice = 0.0;

            while (food != "end")
            {
                switch (food)
                {
                    case "nuts":
                        foodPrice = 2;
                        break;
                    case "water":
                        foodPrice = 0.7;
                        break;
                    case "crisps":
                        foodPrice = 1.5;
                        break;
                    case "soda":
                        foodPrice = 0.8;
                        break;
                    case "coke":
                        foodPrice = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        food = Console.ReadLine().ToLower();
                        continue;
                }

                if (coinSum >= foodPrice)
                {
                    coinSum -= foodPrice;
                    Console.WriteLine($"Purchased {food}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                food = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Change: {coinSum:F2}");
        }
    }
}
