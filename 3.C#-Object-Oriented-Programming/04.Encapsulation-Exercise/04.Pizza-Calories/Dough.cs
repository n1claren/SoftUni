using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Pizza_Calories
{
    public class Dough
    {
        private const string ERROR_DOUGH_MSG = "Invalid type of dough.";
        private const string ERROR_WEIGHT_MSG = "Dough weight should be in the range [1..200].";
        private const double DOUGH_BASE_CALORIES = 2.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flour, string baking, double weight)
        {
            FlourType = flour;
            BakingTechnique = baking;
            Weight = weight;
        }

        private string FlourType 
        {
            get => flourType;

            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(ERROR_DOUGH_MSG);
                }

                flourType = value;
            }
        }
        private string BakingTechnique 
        {
            get => bakingTechnique;

            set
            {
                if (value.ToLower() != "crispy" 
                    && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(ERROR_DOUGH_MSG);
                }

                bakingTechnique = value;
            }
        }

        private double Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ERROR_WEIGHT_MSG);
                }

                weight = value;
            }
        }

        public double GetCalories()
        {
            double flourMod = 0.0;
            double bakingMod = 0.0;

            switch (FlourType.ToLower())
            {
                case "white":
                    flourMod = 1.5;
                    break;

                case "wholegrain":
                    flourMod = 1.0;
                    break;
            }

            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingMod = 0.9;
                    break;

                case "chewy":
                    bakingMod = 1.1;
                    break;

                case "homemade":
                    bakingMod = 1.0;
                    break;
            }

            double calories = DOUGH_BASE_CALORIES * Weight * flourMod * bakingMod;

            return calories;
        }
    }
}
