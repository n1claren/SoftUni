using System;

namespace SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double storageCapacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int suitcaseCounter = 0;
            double suitcaseSize = 0;

            while (input != "End")
            {
                suitcaseSize = Convert.ToDouble(input);
                suitcaseCounter++;

                if (suitcaseCounter % 3 == 0)
                {
                    suitcaseSize += suitcaseSize / 100 * 10;
                }

                storageCapacity -= suitcaseSize;

                if (storageCapacity <= 0)
                {
                    Console.WriteLine($"No more space!");
                    Console.WriteLine($"Statistic: {suitcaseCounter - 1} suitcases loaded.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
                Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");
            }
        }
    }
}
