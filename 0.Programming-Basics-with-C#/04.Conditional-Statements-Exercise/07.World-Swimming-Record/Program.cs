using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double waterResistanceTime = (Math.Floor(distance / 15)) * 12.5;
            double time = distance * secondsPerMeter + waterResistanceTime;

            if (time < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
            else
            {
                double failTime = Math.Abs(record - time);
                Console.WriteLine($"No, he failed! He was {failTime:f2} seconds slower.");
            }

        }
    }
}
