using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> race = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double leftRacerTime = 0.0;
            double rightRacerTime = 0.0;

            for (int i = 0; i < race.Count / 2; i++)
            {
                leftRacerTime += race[i];

                if (race[i] == 0)
                {
                    leftRacerTime *= 0.8;
                }

            }

            for (int i = race.Count - 1; i > race.Count / 2; i--)
            {
                rightRacerTime += race[i];

                if (race[i] == 0)
                {
                    rightRacerTime *= 0.8;
                }

            }

            if (leftRacerTime < rightRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacerTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightRacerTime}");
            }
        }
    }
}
