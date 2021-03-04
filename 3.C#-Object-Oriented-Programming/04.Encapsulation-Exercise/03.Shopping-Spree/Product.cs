using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Shopping_Spree
{
    public class Product
    {
        private const string NAME_ERROR = "Name cannot be empty";
        private const string MONEY_ERROR = "Money cannot be negative";

        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name 
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NAME_ERROR);
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get => this.price;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(MONEY_ERROR);
                }

                this.price = value;
            }
        }
    }
}
