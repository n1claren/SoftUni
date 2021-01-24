using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"%(?<name>[A-Z]{1}[a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+?.\d*)\$";

            Dictionary<string, List<string>> namesAndPurchases = new Dictionary<string, List<string>>();
            double income = 0.0;

            while (input != "end of shift")
            {
                var match = Regex.Match(input, pattern);

                string name = string.Empty;
                string product = string.Empty;
                double price = 0.0;

                if (match.Success)
                {
                    name = match.Groups["name"].Value;
                    product = match.Groups["product"].Value;
                    price = double.Parse(match.Groups["quantity"].Value)
                        * double.Parse(match.Groups["price"].Value);

                    string concat = $"{product} - {price:f2}";

                    if (namesAndPurchases.ContainsKey(name))
                    {
                        namesAndPurchases[name].Add(concat);
                    }
                    else
                    {
                        List<string> productsAndPrices = new List<string>();
                        namesAndPurchases.Add(name, productsAndPrices);
                        namesAndPurchases[name].Add(concat);
                    }

                    income += price;
                }

                input = Console.ReadLine();
            }

            foreach (var customer in namesAndPurchases)
            {
                for (int i = 0; i < customer.Value.Count; i++)
                {
                    Console.WriteLine($"{customer.Key}: {customer.Value[i]}");
                }
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}