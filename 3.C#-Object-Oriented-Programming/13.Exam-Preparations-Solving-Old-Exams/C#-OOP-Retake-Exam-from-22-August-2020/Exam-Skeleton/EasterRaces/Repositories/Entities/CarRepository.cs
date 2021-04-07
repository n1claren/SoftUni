using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public ICar FirstOrDefault { get; internal set; }

        public void Add(ICar model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return (IReadOnlyCollection<ICar>)models;
        }

        public ICar GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
