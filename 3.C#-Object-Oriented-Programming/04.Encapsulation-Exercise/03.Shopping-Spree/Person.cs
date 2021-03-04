using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Shopping_Spree
{
    public class Person
    {
        private const string BOUGHT_MSG = "{0} bought {1}";
        private const string NO_MONEY_MSG = "{0} can't afford {1}";
        private const string NAME_ERROR = "Name cannot be empty";
        private const string MONEY_ERROR = "Money cannot be negative";

        private string name;
        private decimal money;
        private List<string> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;

            products = new List<string>();
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

        public decimal Money
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(MONEY_ERROR);
                }

                this.money = value;
            }
        }

        public IReadOnlyList<string> Products
        {
            get => this.products.AsReadOnly();
        }

        public void ShopProduct(Product product)
        {
            if (this.Money >= product.Price)
            {
                products.Add(product.Name);

                this.Money -= product.Price;

                Console.WriteLine(String.Format(BOUGHT_MSG, this.Name, product.Name));
            }
            else
            {
                Console.WriteLine(String.Format(NO_MONEY_MSG, this.Name, product.Name));
            }
        }

        public override string ToString()
        {
            string productsOutput = 
                this.products.Count > 0 ? string.Join(", ", this.products) : "Nothing bought";

            return $"{this.Name} - {productsOutput}";
        }
    }
}
