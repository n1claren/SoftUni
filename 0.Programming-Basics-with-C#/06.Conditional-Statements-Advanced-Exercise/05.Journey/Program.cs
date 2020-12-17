using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double spendings = 0.0;
            

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    spendings = 0.3; 
                    double spendingsTotal = budget * spendings;

                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {spendingsTotal:F2}");
                }

                else if (season == "winter")
                {
                    spendings = 0.7;
                    double spendingsTotal = budget * spendings;

                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {spendingsTotal:F2}");
                }
            }

            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    spendings = 0.4;
                    double spendingsTotal = budget * spendings;

                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {spendingsTotal:F2}");
                }

                else if (season == "winter")
                {
                    spendings = 0.8;
                    double spendingsTotal = budget * spendings;

                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {spendingsTotal:F2}");
                }
            }

            else if (budget > 1000)
            {
                spendings = 0.9;
                double spendingsTotal = budget * spendings;

                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {spendingsTotal:F2}");
            }
        }
    }
}
