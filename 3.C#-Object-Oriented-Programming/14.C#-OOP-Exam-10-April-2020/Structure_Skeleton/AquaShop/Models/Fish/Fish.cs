using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Runtime.Serialization;

namespace AquaShop.Models.Fish
{
    public class Fish : IFish
    {
        private const int size = 1;

        private string name;
        private string species;
        private decimal price;

        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }

                name = value;
            }
        }

        public string Species
        {
            get => species;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }

                species = value;
            }
        }

        public int Size { get; protected set; }

        public decimal Price
        {
            get => price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                price = value;
            }
        }

        public SerializationInfo ExceptionMessage { get; private set; }

        public virtual void Eat()
        {
            Size++;
        }
    }
}
