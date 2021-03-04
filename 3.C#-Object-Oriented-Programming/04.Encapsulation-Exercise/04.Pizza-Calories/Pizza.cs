using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Pizza_Calories
{
    public class Pizza
    {
        private const string NAME_ERROR_MSG = "Pizza name should be between 1 and 15 symbols.";
        private const string TOPPINGS_COUNT_ERROR_MSG = "Number of toppings should be in range [0..10].";

        private string name;
        private ICollection<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            Name = name;

            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(NAME_ERROR_MSG);
                }

                name = value;
            }
        }

        public Dough Dough
        {
            get => dough;

            set
            {
                dough = value;
            }
        }

        public int Count => toppings.Count;

        public void AddTopping(Topping top)
        {
            if (toppings.Count < 10)
            {
                toppings.Add(top);
            }
            else
            {
                throw new ArgumentException(TOPPINGS_COUNT_ERROR_MSG);
            }
        }

        public double GetCalories()
        {
            double calories = 0.0;

            foreach (Topping topping in toppings)
            {
                calories += topping.GetCalories();
            }

            calories += Dough.GetCalories();

            return calories;
        }

        public override string ToString()
        {
            return $"{Name} - {GetCalories():F2} Calories.";
        }
    }
}
