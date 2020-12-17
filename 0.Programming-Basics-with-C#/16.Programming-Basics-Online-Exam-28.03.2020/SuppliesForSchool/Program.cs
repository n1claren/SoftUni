using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int penPacks = int.Parse(Console.ReadLine());
            int markerPacks = int.Parse(Console.ReadLine());
            double litresCleaner = double.Parse(Console.ReadLine());
            int discountPercent = int.Parse(Console.ReadLine());

            double penPackCost = 5.80;
            double markerPackCost = 7.20;
            double litreCleanerCost = 1.20;

            double penCostTotal = penPacks * penPackCost;
            double markerCostTotal = markerPacks * markerPackCost;
            double cleanerCostTotal = litresCleaner * litreCleanerCost;

            double discount = (penCostTotal + markerCostTotal + cleanerCostTotal) / 100 * discountPercent;
            double moneyNeeded = (penCostTotal + markerCostTotal + cleanerCostTotal) - discount;

            Console.WriteLine($"{moneyNeeded:f3}");
        }
    }
}
