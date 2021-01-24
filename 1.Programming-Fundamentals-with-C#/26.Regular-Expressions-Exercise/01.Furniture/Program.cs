using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double moneySpent = 0.0;
            List<string> furniture = new List<string>();

            string pattern = @">>(?<product>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            Regex regex = new Regex(pattern);

            while (input != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    furniture.Add(match.Groups["product"].Value);
                    moneySpent += double.Parse(match.Groups["price"].Value)
                        * double.Parse(match.Groups["quantity"].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            if (furniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furniture));
            }

            Console.WriteLine($"Total money spend: {moneySpent:f2}");
        }
    }
}