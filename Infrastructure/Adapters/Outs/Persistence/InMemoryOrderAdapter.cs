using Application.Ports.Outs;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class InMemoryOrderAdapter : IOrderRepositoryPort
    {
        private readonly InMemoryOrderRepository _repository;

        public InMemoryOrderAdapter(InMemoryOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Save(Order order)
        {
            var entity = OrderMapper.ToEntity(order);
            var savedEntity = _repository.Save(entity);
            return OrderMapper.ToDomain(savedEntity);
        }

        public Order GetOrder(int orderId)
        {
            var entity = _repository.FindById(orderId);
            if (entity is null)
                throw new BusinessException($"No existe la orden con id {orderId}.");
            return OrderMapper.ToDomain(entity);
        }
    }
}