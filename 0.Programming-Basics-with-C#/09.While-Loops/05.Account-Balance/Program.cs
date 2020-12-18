using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double increase = 0.0;
            double balance = 0.0;

            while (input != "NoMoreMoney")
            {
                increase = double.Parse(input);

                if (increase < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                balance += increase;

                Console.WriteLine($"Increase: {increase:F2}");

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {balance:F2}");
        }
    }
}
