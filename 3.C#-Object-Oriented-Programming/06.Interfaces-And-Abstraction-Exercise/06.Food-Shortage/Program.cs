using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Food_Shortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<Rebel> rebels = new List<Rebel>();
            List<Human> people = new List<Human>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);

                    rebels.Add(rebel);
                }
                else if (input.Length == 4)
                {
                    Human human = new Human(input[0], int.Parse(input[1]), input[2], input[3]);

                    people.Add(human);
                }
            }

            string boughtFood = string.Empty;

            while ((boughtFood = Console.ReadLine()) != "End")
            {
                Human foodBuyerPerson = people.FirstOrDefault(p => p.Name == boughtFood);
                Rebel foodBuyerRebel = rebels.FirstOrDefault(r => r.Name == boughtFood);

                if (foodBuyerPerson != null)
                {
                    foodBuyerPerson.BuyFood();
                }
                
                if (foodBuyerRebel != null)
                {
                    foodBuyerRebel.BuyFood();
                }
            }

            int totalFoodPurchased = 0;

            foreach (Human person in people)
            {
                totalFoodPurchased += person.Food;
            }

            foreach (Rebel rebel in rebels)
            {
                totalFoodPurchased += rebel.Food;
            }

            Console.WriteLine(totalFoodPurchased);
        }
    }
}
