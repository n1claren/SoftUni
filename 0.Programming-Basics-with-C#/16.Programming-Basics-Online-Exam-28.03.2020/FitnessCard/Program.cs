using System;

namespace FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double cost = 0.0;

            switch (sport)
            {
                case "Gym":
                    if (gender == "f")
                    {
                        cost = 35;
                    }
                    else
                    {
                        cost = 42;
                    }
                    break;
                case "Boxing":
                    if (gender == "f")
                    {
                        cost = 37;
                    }
                    else
                    {
                        cost = 41;
                    }
                    break;
                case "Yoga":
                    if (gender == "f")
                    {
                        cost = 42;
                    }
                    else
                    {
                        cost = 45;
                    }
                    break;
                case "Zumba":
                    if (gender == "f")
                    {
                        cost = 31;
                    }
                    else
                    {
                        cost = 34;
                    }
                    break;
                case "Dances":
                    if (gender == "f")
                    {
                        cost = 53;
                    }
                    else
                    {
                        cost = 51;
                    }
                    break;
                case "Pilates":
                    if (gender == "f")
                    {
                        cost = 37;
                    }
                    else
                    {
                        cost = 39;
                    }
                    break;
            }

            if (age <= 19)
            {
                cost -= cost / 5;
            }

            if (budget >= cost)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${(cost - budget):F2} more.");
            }
        }
    }
}
