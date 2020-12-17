using System;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogs = double.Parse(Console.ReadLine());
            double otherAnimals = double.Parse(Console.ReadLine());
            double dogFoodCost = dogs * 2.50;
            double animalFoodCost = otherAnimals * 4;
            double totalCost = dogFoodCost + animalFoodCost;


            Console.WriteLine($"{totalCost} lv.");

        }
    }
}
