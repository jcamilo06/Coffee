using Application.Ports.In.Interfaces;
using Application.Ports.Outs.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases
{
    public class CoffeeBeanQueryUseCase : ICoffeeBeanQueryUseCase
    {
        private readonly ICoffeeBeanPort _coffeeBeanPort;

        public CoffeeBeanQueryUseCase(ICoffeeBeanPort coffeeBeanPort)
        {
            _coffeeBeanPort = coffeeBeanPort;
        }

        public List<CoffeeBean> GetAllCoffeeBeans() => _coffeeBeanPort.GetAll();
    }
}
