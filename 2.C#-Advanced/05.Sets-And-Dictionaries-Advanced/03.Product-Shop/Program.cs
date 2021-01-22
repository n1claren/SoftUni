using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Dictionary<string, double>> shops = 
                new Dictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] shopData = input.Split(", ");

                string shop = shopData[0];
                string product = shopData[1];
                double price = double.Parse(shopData[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, price);
                }

                shops[shop][product] = price;
            }

            shops = shops.OrderBy(s => s.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
