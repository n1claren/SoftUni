using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double hillSlowage = Math.Floor(distance / 50) * 30;

            double time = (distance * timePerMeter) + hillSlowage;

            if (currentRecord <= time)
            {
                Console.WriteLine($"No! He was {(time - currentRecord):F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($" Yes! The new record is {time:F2} seconds.");
            }
        }
    }
}
