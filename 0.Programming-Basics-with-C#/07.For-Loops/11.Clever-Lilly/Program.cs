using System;

namespace CleverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            int moneyGifts = 0;
            int toyGifts = 0;

            for (int i = 1; i <= age; i++)
            {
              if (i % 2 == 0)
                {
                    moneyGifts += 1;
                }

              if (i % 2 != 0)
                {
                    toyGifts += 1;
                }
            }

            int money = 0;

            for (int i = 1; i <= moneyGifts; i++)
            {
                money += i * 10;
            }

            int moneyGiftsTotal = money - moneyGifts;
            double moneyToysTotal = toyGifts * toysPrice;

            double savingsTotal = moneyGiftsTotal + moneyToysTotal;

            if (savingsTotal >= washingMachinePrice)
            {
                double moneyLeft = savingsTotal - washingMachinePrice;
                Console.WriteLine($"Yes! {moneyLeft:F2}");
            }

            else if (washingMachinePrice > savingsTotal)
            {
                double moneyNeeded = washingMachinePrice - savingsTotal;
                Console.WriteLine($"No! {moneyNeeded:F2}");
            }
        }
    }
}
