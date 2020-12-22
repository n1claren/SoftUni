using System;

namespace _03.Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            double totalSpent = 0.0;

            while (input != "Game Time")
            {
                double price = 0.0;
                bool gameFound = true;

                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;

                    case "CS: OG":
                        price = 15.99;
                        break;

                    case "Zplinter Zell":
                        price = 19.99;
                        break;

                    case "Honored 2":
                        price = 59.99;
                        break;

                    case "RoverWatch":
                        price = 29.99;
                        break;

                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        gameFound = false;
                        break;
                }

                if (gameFound)
                {
                    if (currentBalance >= price)
                    {
                        currentBalance -= price;
                        totalSpent += price;

                        Console.WriteLine($"Bought {input}");

                        if (currentBalance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            input = "Game Time";
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                        input = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${currentBalance:f2}");
        }
    }
}
