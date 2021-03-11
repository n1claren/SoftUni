using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Wild_Farm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
                Weight += 1.00 * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override void Sound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}