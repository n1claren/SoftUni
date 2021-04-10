using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IFish> fish;
        private ICollection<IDecoration> decorations;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            fish = new List<IFish>();
            decorations = new List<IDecoration>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
        {
            get
            {
                int comform = 0;

                foreach (var decoration in decorations)
                {
                    comform += decoration.Comfort;
                }

                return comform;
            }
        }

        public ICollection<IDecoration> Decorations
        {
            get => decorations;
        }

        public ICollection<IFish> Fish
        {
            get => fish;
        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Capacity <= this.fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{name} ({GetType().Name}):");

            if (fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", fish.Select(x => x.Name))}");
            }

            sb.AppendLine($"Decorations: {decorations.Count}");

            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
