using System;

namespace FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double nightPrice = double.Parse(Console.ReadLine());
            int sideExpensesPercentage = int.Parse(Console.ReadLine());

            if (nights > 7)
            {
                nightPrice -= nightPrice * 0.05;
            }

            double nightsCost = nightPrice * nights;

            double sideExpenses = budget * sideExpensesPercentage / 100;

            double totalCost = nightsCost + sideExpenses;

            if (totalCost <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {(budget - totalCost):F2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{(totalCost - budget):F2} leva needed.");
            }
        }
    }
}
