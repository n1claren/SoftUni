using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string food)
        {
            Name = name;
            FavouriteFood = food;
        }

        public string Name { get; private set; }
        public string FavouriteFood { get; set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {FavouriteFood}";
        }
    }
}
