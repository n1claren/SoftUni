using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private ICollection<IDriver> models;

        public DriverRepository()
        {
            models = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return (IReadOnlyCollection<IDriver>)models;
        }

        public IDriver GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return models.Remove(model);
        }
    }
}
