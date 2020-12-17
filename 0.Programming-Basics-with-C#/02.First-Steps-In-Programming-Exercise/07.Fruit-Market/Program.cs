using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaWeight = double.Parse(Console.ReadLine());
            double orangeWeight = double.Parse(Console.ReadLine());
            double raspberryWeight = double.Parse(Console.ReadLine());
            double strawberryWeight = double.Parse(Console.ReadLine());
            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice - (raspberryPrice / 100 * 40);
            double bananaPrice = raspberryPrice - (raspberryPrice / 100 * 80);
            double strawberryPriceTotal = strawberryPrice * strawberryWeight;
            double bananaPriceTotal = bananaPrice * bananaWeight;
            double orangePriceTotal = orangePrice * orangeWeight;
            double raspberryPriceTotal = raspberryPrice * raspberryWeight;
            double totalPrice = raspberryPriceTotal + strawberryPriceTotal + orangePriceTotal + bananaPriceTotal;
            Console.WriteLine(totalPrice);



        }
    }
}
