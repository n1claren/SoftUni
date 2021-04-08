using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved = false;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved
        {
            get => isReserved;

            private set
            {
                isReserved = value;
            }
        }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            isReserved = false;
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal peoplePrice = PricePerPerson * NumberOfPeople;
            decimal drinksPrice = 0m;
            decimal foodsPrice = 0m;

            foreach (var drink in drinkOrders)
            {
                drinksPrice += drink.Price;
            }

            foreach (var food in foodOrders)
            {
                foodsPrice += food.Price;
            }

            return peoplePrice + drinksPrice + foodsPrice;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            isReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
