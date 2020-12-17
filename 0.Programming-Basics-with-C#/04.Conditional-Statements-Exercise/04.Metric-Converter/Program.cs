using System;

namespace Metrics
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string initialMetric = Console.ReadLine();
            string convertMetric = Console.ReadLine();

            double mToMM = 1000;
            double mmToM = 0.001;

            double mToCM = 100;
            double CmToM = 0.01;

            double CmToMM = 10;
            double mmToCM = 0.1;

            if (initialMetric == "cm")
            {
                if (convertMetric == "cm")
                {
                    Console.WriteLine($"{num:F3}");
                }
                else if (convertMetric == "mm")
                {
                    double convertnum = num * CmToMM;
                    Console.WriteLine($"{convertnum:F3}");
                }
                else if (convertMetric == "m")
                {
                    double convertnum = num * CmToM;
                    Console.WriteLine($"{convertnum:F3}");
                }
            }
            else if (initialMetric == "m")
            {
                if (convertMetric == "mm")
                {
                    double convertnum = num * mToMM;
                    Console.WriteLine($"{convertnum:F3}");
                }
                else if (convertMetric == "m")
                {
                    Console.WriteLine($"{num:F3}");
                }
                else if (convertMetric == "cm")
                {
                    double convertnum = num * mToCM;
                    Console.WriteLine($"{convertnum:F3}");
                }
            }
            else if (initialMetric == "mm")
            {
                if (convertMetric == "mm")
                {
                    Console.WriteLine($"{num:F3}");
                }
                else if (convertMetric == "cm")
                {
                    double convertnum = num * mmToCM;
                    Console.WriteLine($"{convertnum:F3}");
                }
                else if (convertMetric == "m")
                {
                    double convertnum = num * mmToM;
                    Console.WriteLine($"{convertnum:F3}");
                }


            }
        }
    }
}
