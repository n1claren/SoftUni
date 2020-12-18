using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationCost = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            int spendSpree = 0;
            int days = 0;
            bool isCapable = true;

            while (vacationCost > budget)
            {
                string action = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());

                days++;

                if (action == "spend")
                {
                    spendSpree++;

                    if (spendSpree == 5)
                    {
                        isCapable = false;
                        break;
                    }

                    budget -= sum;

                    if (budget < 0)
                    {
                        budget = 0;
                    }    
                }

                else if (action == "save")
                {
                    spendSpree = 0;
                    budget += sum;
                }
            }

            if (isCapable)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }

        }
    }
}
