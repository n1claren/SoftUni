using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();
            int quantity = int.Parse(Console.ReadLine());

            OrderPriceCalculator(product, quantity);
        }

        static void OrderPriceCalculator(string product, int quantity)
        {
            double price = 0;
            double cost = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;
            }

            cost = price * quantity;
            Console.WriteLine($"{cost:F2}");
        }
    }
}