using Domain.Models;
using Infrastructure.Adapters.Outs.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class OrderMapper
    {
        public static Order ToDomain(OrderEntity entity)
        {
            return new Order(entity.Id, entity.CustomerName, entity.Grams, entity.Date, entity.TotalPrice, entity.CoffeeBeanId, entity.BrewingMethodId);
        }
        public static OrderEntity ToEntity(Order domain)
        {
            return new OrderEntity(domain.Id, domain.CustomerName, domain.Grams, domain.Date, domain.TotalPrice, domain.CoffeeBeanId, domain.BrewingMethodId);
        }
    }
}
