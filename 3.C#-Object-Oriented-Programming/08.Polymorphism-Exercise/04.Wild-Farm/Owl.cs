using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Wild_Farm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override void Eat(Food food)
        {
            if (!(food.GetType().Name == nameof(Meat)))
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += 0.25 * food.Quantity;
                FoodEaten += food.Quantity;
            }

        }

        public override void Sound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}