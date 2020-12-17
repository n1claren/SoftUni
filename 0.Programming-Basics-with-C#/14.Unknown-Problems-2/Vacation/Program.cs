using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();

            double price = 0;

            switch (groupType)
            {
                case "students":
                    if (day == "friday")
                    {
                        price = 8.45;
                    }
                    else if (day == "saturday")
                    {
                        price = 9.80;
                    }
                    else if (day == "sunday")
                    {
                        price = 10.46;
                    }
                    break;

                case "business":
                    if (day == "friday")
                    {
                        price = 10.90;
                    }
                    else if (day == "saturday")
                    {
                        price = 15.60;
                    }
                    else if (day == "sunday")
                    {
                        price = 16.00;
                    }
                    break;

                case "regular":
                    if (day == "friday")
                    {
                        price = 15.00;
                    }
                    else if (day == "saturday")
                    {
                        price = 20.00;
                    }
                    else if (day == "sunday")
                    {
                        price = 22.50;
                    }
                    break;

                default:
                    Console.WriteLine("Error!");
                    break;
            }

            if (groupType == "students" && groupSize >= 30)
            {
                price -= price * 0.15;
            }

            if (groupType == "business" && groupSize >= 100)
            {
                groupSize -= 10;
            }

            if (groupType == "regular" && groupSize >= 10 && groupSize <= 20)
            {
                price -= price * 0.05;
            }

            double totalPrice = price * groupSize;

            Console.WriteLine($"Total price: {totalPrice:F2}");


        }
    }
}
