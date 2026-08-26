using Domain.Models;
using Infrastructure.Adapters.Outs.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class BrewingMethodMapper
    {
        public static BrewingMethod ToDomain(BrewingMethodEntity entity)
        {
            return new BrewingMethod(entity.Id, entity.Name, entity.Cost);
        }
        public static BrewingMethodEntity ToEntity(BrewingMethod domain)
        {
            return new BrewingMethodEntity(domain.Id, domain.Name, domain.Cost);
        }
    }
}
