using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablePricePerKG = double.Parse(Console.ReadLine());
            double fruitPricePerKG = double.Parse(Console.ReadLine());
            double vegetableSumKG = double.Parse(Console.ReadLine());
            double fruitSumKG = double.Parse(Console.ReadLine());
            double fruitProfit = fruitPricePerKG * fruitSumKG;
            double vegetableProfit = vegetablePricePerKG * vegetableSumKG;
            double allProfit = vegetableProfit + fruitProfit;
            double euroCourse = 1.94;
            double profitEuro = allProfit / euroCourse;
            Console.WriteLine($"{profitEuro:f2}"); 
        }
    }
}
