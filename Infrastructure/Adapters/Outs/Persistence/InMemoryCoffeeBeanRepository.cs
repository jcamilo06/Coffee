using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class InMemoryCoffeeBeanRepository
    {
        private readonly Dictionary<int, CoffeeBeanEntity> _beans = new();

        public InMemoryCoffeeBeanRepository()
        {
            // Datos semilla para poder probar sin montar otro endpoint de "crear grano"
            _beans[1] = new CoffeeBeanEntity(1, "Geisha", 25000m, 5000m);
            _beans[2] = new CoffeeBeanEntity(2, "Bourbon Rosado", 18000m, 3000m);
        }

        public CoffeeBeanEntity Save(CoffeeBeanEntity entity)
        {
            _beans[entity.Id] = entity;
            return entity;
        }

        public CoffeeBeanEntity FindById(int id)
        {
            return _beans.TryGetValue(id, out var entity) ? entity : null;
        }

        public List<CoffeeBeanEntity> FindAll()
        {
            return _beans.Values.ToList();
        }
    }
}