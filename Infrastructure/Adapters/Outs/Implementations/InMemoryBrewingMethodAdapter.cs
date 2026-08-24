using Application.Ports.Outs.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Implementations
{
    public class InMemoryBrewingMethodAdapter : IBrewingMethodPort
    {
        private readonly Dictionary<int, BrewingMethod> _methods = new();

        public InMemoryBrewingMethodAdapter()
        {
            _methods[1] = new BrewingMethod(1, "V60", 3000m);
            _methods[2] = new BrewingMethod(2, "Chemex", 3500m);
            _methods[3] = new BrewingMethod(3, "Espresso", 5000m);
            _methods[4] = new BrewingMethod(4, "Prensa Francesa", 2500m);
            _methods[5] = new BrewingMethod(5, "Aeropress", 3000m);
        }

        public BrewingMethod GetById(int brewingMethodId)
        {
            if (!_methods.TryGetValue(brewingMethodId, out var method))
                throw new BusinessException($"No existe el método de preparación con id {brewingMethodId}.");
            return method;
        }

        public List<BrewingMethod> GetAll()
        {
            return _methods.Values.ToList();
        }
    }
}
