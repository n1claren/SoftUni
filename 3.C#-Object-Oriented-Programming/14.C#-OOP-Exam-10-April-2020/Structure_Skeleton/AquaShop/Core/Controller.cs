using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType); 
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (aquarium.GetType().Name == "FreshwaterAquarium" && fishType == "FreshwaterFish")
            {
                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (aquarium.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish")
            {
                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater; 
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal value = 0;

            value += aquarium.Fish.Sum(x => x.Price);
            value += aquarium.Decorations.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            decorations.Remove(decoration);

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.AddDecoration(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
