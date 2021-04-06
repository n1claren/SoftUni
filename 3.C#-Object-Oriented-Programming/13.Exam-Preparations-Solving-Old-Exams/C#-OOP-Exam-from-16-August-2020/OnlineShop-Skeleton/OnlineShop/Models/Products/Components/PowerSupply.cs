﻿namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        public PowerSupply(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance, 
            int generation) 
            : base(id, manufacturer, model, price, overallPerformance * 1.05, generation)
        {

        }
    }
}
