using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripCost = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int speakingDollCount = int.Parse(Console.ReadLine());
            int teddyBearCount = int.Parse(Console.ReadLine());
            int minionCount = int.Parse(Console.ReadLine());
            int truckCount = int.Parse(Console.ReadLine());
            double puzzlePrice = 2.60;
            double speakingDollPrice = 3.00;
            double teddyBearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2.00;
            double truckProfit = truckCount * truckPrice;
            double minionProfit = minionCount * minionPrice;
            double teddyBearProfit = teddyBearCount * teddyBearPrice;
            double puzzleProfit = puzzleCount * puzzlePrice;
            double speakingDollProfit = speakingDollCount * speakingDollPrice;
            double allProfit = puzzleProfit + speakingDollProfit + teddyBearProfit + minionProfit + truckProfit;
            double rent = allProfit * 10 / 100;
            double toysCount = (puzzleCount + speakingDollCount + teddyBearCount + minionCount + truckCount);
            double profitDiscount = allProfit - (allProfit * 25 / 100);
            double rentDiscount = profitDiscount * 10 / 100;
            double netProfit = allProfit - rent;
            double netProfitDiscount = profitDiscount - rentDiscount;
            if (toysCount >= 50)
            {
               if (netProfitDiscount >= tripCost)
                {
                    double moneyLeft = netProfitDiscount - tripCost;
                    Console.WriteLine($"Yes! {moneyLeft:F2} lv left."); }
               else
                { double moneyNeeded = tripCost - netProfitDiscount;
                    Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
                }                    
            }
            else
            { if (tripCost <= netProfit)
                {
                    double moneyLeft = netProfit - tripCost;
                    Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
                }
                else
                { double moneyNeeded = tripCost - netProfit;
                    Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
                }
            }

        }
    }
}
