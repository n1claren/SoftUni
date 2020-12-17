using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rentCost = double.Parse(Console.ReadLine());
            double cakeCost = rentCost / 5;
            double drinksCost = cakeCost - (cakeCost / 100 * 45);
            double animatorCost = rentCost / 3;
            double budget = rentCost + drinksCost + cakeCost + animatorCost;
            Console.WriteLine(budget);
        }
    }
}
