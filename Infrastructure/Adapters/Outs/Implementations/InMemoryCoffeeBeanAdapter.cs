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
    public class InMemoryCoffeeBeanAdapter : ICoffeeBeanPort
    {
        private readonly Dictionary<int, CoffeeBean> _beans = new();

        public InMemoryCoffeeBeanAdapter()
        {
            // Datos semilla para poder probar sin montar otro endpoint de "crear grano"
            _beans[1] = new CoffeeBean(1, "Geisha", 25000m, 5000m);
            _beans[2] = new CoffeeBean(2, "Bourbon Rosado", 18000m, 3000m);
        }

        public CoffeeBean GetById(int coffeeBeanId)
        {
            if (!_beans.TryGetValue(coffeeBeanId, out var bean))
                throw new BusinessException($"No existe el grano con id {coffeeBeanId}.");
            return bean;
        }

        public void Update(CoffeeBean coffeeBean) => _beans[coffeeBean.Id] = coffeeBean;
    }
}
