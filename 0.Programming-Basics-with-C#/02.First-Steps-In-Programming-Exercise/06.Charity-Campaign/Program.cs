using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {

            //final version

            int campaignDays = int.Parse(Console.ReadLine());
            int cooks = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int goufrette = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            int cakesTotal = cakes * cooks * campaignDays;
            int goufretteTotal = goufrette * cooks * campaignDays;
            int pancakesTotal = pancakes * cooks * campaignDays;
            double cakesPrice = 45;
            double goufrettePrice = 5.80;
            double pancakesPrice = 3.20;
            double cakesCost = cakesTotal * cakesPrice;
            double goufretteCost = goufretteTotal * goufrettePrice;
            double pancakesCost = pancakesTotal * pancakesPrice;
            double campaignCost = cakesCost + pancakesCost + goufretteCost;
            double campaignExpenses = campaignCost / 8;
            double campaignProfit = campaignCost - campaignExpenses;
            Console.WriteLine(campaignProfit);



        }
    }
}
