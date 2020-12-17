using System;

namespace GodzillaVSKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int staff = int.Parse(Console.ReadLine());
            double pricePerStaffMember = double.Parse(Console.ReadLine());

            double decorationCost = budget / 100 * 10;
            double staffCost = staff * pricePerStaffMember;
            
            if (staff > 150)
            {
                staffCost = staffCost - (staffCost / 100 * 10);
            }

            double totalcost = decorationCost + staffCost;

            if (budget >= totalcost)
            {
                double budgetleft = budget - totalcost;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetleft:f2} leva left.");
            }

            else
            {
                double moneyneeded = totalcost - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyneeded:f2} leva more.");
            }


        }
    }
}
