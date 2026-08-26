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
    public class InMemoryCoffeeBeanAdapter : ICoffeeBeanPort
    {
        private readonly InMemoryCoffeeBeanRepository _repository;

        public InMemoryCoffeeBeanAdapter(InMemoryCoffeeBeanRepository repository)
        {
            _repository = repository;
        }

        public CoffeeBean GetById(int coffeeBeanId)
        {
            var entity = _repository.FindById(coffeeBeanId);
            if (entity is null)
                throw new BusinessException($"No existe el grano con id {coffeeBeanId}.");
            return CoffeeBeanMapper.ToDomain(entity);
        }

        public void Update(CoffeeBean coffeeBean)
        {
            var entity = CoffeeBeanMapper.ToEntity(coffeeBean);
            _repository.Save(entity);
        }

        public List<CoffeeBean> GetAll()
        {
            return _repository.FindAll().Select(CoffeeBeanMapper.ToDomain).ToList();
        }
    }
}
