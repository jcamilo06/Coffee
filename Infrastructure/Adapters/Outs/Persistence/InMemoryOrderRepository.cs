using Application.Ports.Outs;
using Domain.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class InMemoryOrderRepository
    {
        private readonly Dictionary<int, OrderEntity> _orders = new();
        private int _nextId = 1;

        public OrderEntity Save(OrderEntity entity)
        {
            if (entity.Id == 0)
            {
                entity.Id = _nextId++;
            }
            _orders[entity.Id] = entity;
            return entity;
        }

        public OrderEntity FindById(int id)
        {
            return _orders.TryGetValue(id, out var entity) ? entity : null;
        }

        public List<OrderEntity> FindAll()
        {
            return _orders.Values.ToList();
        }
    }
}
