using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class InMemoryBrewingMethodRepository
    {
        private readonly Dictionary<int, BrewingMethodEntity> _methods = new();

        public InMemoryBrewingMethodRepository()
        {
            _methods[1] = new BrewingMethodEntity(1, "V60", 3000m);
            _methods[2] = new BrewingMethodEntity(2, "Chemex", 3500m);
            _methods[3] = new BrewingMethodEntity(3, "Espresso", 5000m);
            _methods[4] = new BrewingMethodEntity(4, "Prensa Francesa", 2500m);
            _methods[5] = new BrewingMethodEntity(5, "Aeropress", 3000m);
        }

        public BrewingMethodEntity Save(BrewingMethodEntity entity)
        {
            _methods[entity.Id] = entity;
            return entity;
        }

        public BrewingMethodEntity FindById(int id)
        {
            return _methods.TryGetValue(id, out var entity) ? entity : null;
        }

        public List<BrewingMethodEntity> FindAll()
        {
            return _methods.Values.ToList();
        }
    }
}
