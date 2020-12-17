using System;
using System.Transactions;

namespace ExamPreparationPB2019JulyVersionOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entry = double.Parse(Console.ReadLine());
            double sunbedPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double entryCost = entry * people;

            double sunbedPeople = Math.Ceiling(people * 0.75);

            double umbrellas = Math.Ceiling((double)people / 2);

            double umbrellaCost = umbrellaPrice * umbrellas;

            double sunbedCost = sunbedPeople * sunbedPrice;

            double totalCost = sunbedCost + umbrellaCost + entryCost;

            Console.WriteLine($"{totalCost:F2} lv.");
        }
    }
}
