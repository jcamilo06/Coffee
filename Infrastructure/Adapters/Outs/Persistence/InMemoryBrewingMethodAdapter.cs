using Application.Ports.Outs;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class InMemoryBrewingMethodAdapter : IBrewingMethodPort
    {
        private readonly InMemoryBrewingMethodRepository _repository;

        public InMemoryBrewingMethodAdapter(InMemoryBrewingMethodRepository repository)
        {
            _repository = repository;
        }

        public BrewingMethod GetById(int brewingMethodId)
        {
            var entity = _repository.FindById(brewingMethodId);
            if (entity is null)
                throw new BusinessException($"No existe el método de preparación con id {brewingMethodId}.");
            return BrewingMethodMapper.ToDomain(entity);
        }

        public List<BrewingMethod> GetAll()
        {
            return _repository.FindAll()
                .Select(BrewingMethodMapper.ToDomain)
                .ToList();
        }
    }
}
