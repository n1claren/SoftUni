using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)decorations;

        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = decorations.FirstOrDefault(d => d.GetType().Name == type);
            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            return decorations.Remove(model);
        }
    }
}
