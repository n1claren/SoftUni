using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Pizza_Calories
{
    public class Topping
    {
        private const string INVALID_TOPPING_MSG = "Cannot place {0} on top of your pizza.";
        private const string INVALID_WEIGHT_MSG = "{0} weight should be in the range [1..50].";
        private const double TOPPING_BASE_CALORIES = 2.0;

        private string toppingType;
        private double weight;

        public Topping(string toping, double weight)
        {
            ToppingType = toping;
            Weight = weight;
        }

        private string ToppingType
        {
            get => toppingType;

            set
            {
                if (value.ToLower() != "meat" 
                    && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" 
                    && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(String.Format(INVALID_TOPPING_MSG, value));
                }

                toppingType = value;
            }
        }

        private double Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(String.Format(INVALID_WEIGHT_MSG, ToppingType));
                }

                weight = value;
            }
        }

        public double GetCalories()
        {
            double toppingMod = 0.0;

            switch (ToppingType.ToLower())
            {
                case "meat":
                    toppingMod = 1.2;
                    break;

                case "veggies":
                    toppingMod = 0.8;
                    break;

                case "cheese":
                    toppingMod = 1.1;
                    break;

                case "sauce":
                    toppingMod = 0.9;
                    break;

            }

            double calories = TOPPING_BASE_CALORIES * toppingMod * Weight;

            return calories;
        }
    }
}
