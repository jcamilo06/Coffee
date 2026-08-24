using Application.Ports.Outs.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Implementations
{
    public class InMemoryOrderAdapter : IOrderRepositoryPort
    {
        private readonly Dictionary<int, Order> _orders = new();
        private int _nextId = 1;

        public Order Save(Order order)
        {
            var orderToSave = new Order(
                id: _nextId++,
                customerName: order.CustomerName,
                grams: order.Grams,
                totalPrice: order.TotalPrice,
                coffeeBeanId: order.CoffeeBeanId,
                brewingMethodId: order.BrewingMethodId);

            _orders[orderToSave.Id] = orderToSave;
            return orderToSave;
        }

        public Order GetOrder(int orderId)
        {
            if (!_orders.TryGetValue(orderId, out var order))
                throw new BusinessException($"No existe la orden con id {orderId}.");
            return order;
        }
    }
}
