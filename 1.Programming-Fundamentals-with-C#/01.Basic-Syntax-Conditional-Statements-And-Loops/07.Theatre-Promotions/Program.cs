using System;

namespace TheatrePromotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());

            int price = 0;

            switch (dayType)
            {
                case "weekday":
                    if (age >= 0 && age <= 18)
                    {
                        price = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 18;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price = 12;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;

                case "weekend":
                    if (age >= 0 && age <= 18)
                    {
                        price = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 20;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price = 15;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;

                case "holiday":
                    if (age >= 0 && age <= 18)
                    {
                        price = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price = 10;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;
            }

            if (price != 0)
            {
                Console.WriteLine($"{price}$");
            }

        }

    }
}
