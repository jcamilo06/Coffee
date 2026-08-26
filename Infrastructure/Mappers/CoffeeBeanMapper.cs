using Domain.Models;
using Infrastructure.Adapters.Outs.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class CoffeeBeanMapper
    {
        public static CoffeeBean ToDomain(CoffeeBeanEntity entity)
        {
            return new CoffeeBean(entity.Id, entity.Name, entity.Price, entity.GramsStock);
        }
        public static CoffeeBeanEntity ToEntity(CoffeeBean domain)
        {
            return new CoffeeBeanEntity(domain.Id, domain.Name, domain.Price, domain.GramsStock);
        }
    }
}
