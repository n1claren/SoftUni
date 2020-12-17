using System;

namespace Comission
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double comission = 0.0;

            switch (town)
            {
                case "Varna":
                    if (sales >= 0 && sales <= 500)
                    {
                        comission = 0.045 * sales;
                    }
                    else if (sales >= 501 && sales <= 1000)
                    {
                        comission = 0.075 * sales;
                    }    
                    else if (sales >= 1001 && sales <= 10000)
                    {
                        comission = 0.1 * sales;
                    }
                    else if (sales >= 10001)
                    {
                        comission = 0.13 * sales;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "Sofia":
                    if (sales >= 0 && sales <= 500)
                    {
                        comission = 0.05 * sales;
                    }
                    else if (sales >= 501 && sales <= 1000)
                    {
                        comission = 0.07 * sales;
                    }
                    else if (sales >= 1001 && sales <= 10000)
                    {
                        comission = 0.08 * sales;
                    }
                    else if (sales >= 10001)
                    {
                        comission = 0.12 * sales;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "Plovdiv":
                    if (sales >= 0 && sales <= 500)
                    {
                        comission = 0.055 * sales;
                    }
                    else if (sales >= 501 && sales <= 1000)
                    {
                        comission = 0.08 * sales;
                    }
                    else if (sales >= 1001 && sales <= 10000)
                    {
                        comission = 0.12 * sales;
                    }
                    else if (sales >= 10000)
                    {
                        comission = 0.145 * sales;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;

            }
            if (comission != 0.0)
            {
                Console.WriteLine($"{comission:F2}");
            }
        }
    }
}
