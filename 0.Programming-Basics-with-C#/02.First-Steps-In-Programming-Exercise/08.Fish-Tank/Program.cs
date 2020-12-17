using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            double tankLenghtCM = double.Parse(Console.ReadLine());
            double tankWidthCM = double.Parse(Console.ReadLine());
            double tankHeightCM = double.Parse(Console.ReadLine());
            double tankPercentageTaken = double.Parse(Console.ReadLine());
            double tankCm3 = tankHeightCM * tankLenghtCM * tankWidthCM;
            double tankLitres = tankCm3 * 0.001;
            double tankWaterFill = tankLitres - (tankLitres / 100 * tankPercentageTaken);
            Console.WriteLine(tankWaterFill);

        }
    }
}
