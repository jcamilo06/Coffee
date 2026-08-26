using Application.Ports.In;
using Application.Ports.Outs;
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

        public bool CheckAvailability(int coffeeBeanId, decimal grams)
        {
            var coffeeBean = _coffeeBeanPort.GetById(coffeeBeanId);
            return coffeeBean.HasEnoughStock(grams);
        }
    }
}
