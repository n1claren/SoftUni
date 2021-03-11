using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Wild_Farm
{
    public abstract class Animal
    {
        private int foodEaten = 0;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; set; }
        public int FoodEaten
        {
            get => this.foodEaten;

            set
            {
                foodEaten = value;
            }
        }

        public abstract void Sound();

        public abstract void Eat(Food food);

    }
}
