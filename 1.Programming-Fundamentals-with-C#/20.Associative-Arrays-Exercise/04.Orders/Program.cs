using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            while (input != "buy")
            {
                string[] inputCollection = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string productName = inputCollection[0];
                double productPrice = double.Parse(inputCollection[1]);
                double productQuantity = double.Parse(inputCollection[2]);

                List<double> productData = new List<double>();
                productData.Add(productPrice);
                productData.Add(productQuantity);

                if (products.ContainsKey(productName))
                {
                    if (products[productName][0] != productPrice)
                    {
                        products[productName][0] = productPrice;
                    }

                    products[productName][1] += productQuantity;
                }
                else
                {
                    products.Add(productName, productData);
                }

                input = Console.ReadLine();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            }
        }
    }
}
