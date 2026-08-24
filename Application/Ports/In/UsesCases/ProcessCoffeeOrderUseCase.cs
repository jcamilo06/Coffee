using Application.Ports.In.Interfaces;
using Application.Ports.Outs.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.In.UsesCases
{
    public class ProcessCoffeeOrderUseCase : IProcessCoffeeOrderUseCase
    {
        private readonly ICoffeeBeanPort _coffeeBeanPort;
        private readonly IBrewingMethodPort _brewingMethodPort;
        private readonly IOrderRepositoryPort _orderRepositoryPort;

        public ProcessCoffeeOrderUseCase(
            ICoffeeBeanPort inventoryPort,
            IBrewingMethodPort brewingMethodPort,
            IOrderRepositoryPort orderRepositoryPort)
        {
            _coffeeBeanPort = inventoryPort;
            _brewingMethodPort = brewingMethodPort;
            _orderRepositoryPort = orderRepositoryPort;
        }

        public bool CheckAvailability(int coffeeBeanId, decimal grams)
        {
            var coffeeBean = _coffeeBeanPort.GetById(coffeeBeanId);
            return coffeeBean.HasEnoughStock(grams);
        }

        public Order ProcessOrder(string customerName, decimal grams, int coffeeBeanId, int brewingMethodId)
        {
            // Obtener el grano y el método de preparación
            var coffeeBean = _coffeeBeanPort.GetById(coffeeBeanId);
            var brewingMethod = _brewingMethodPort.GetById(brewingMethodId);

            // Descontar los gramos pedidos en la orden
            coffeeBean.DecreaseStock(grams);
            _coffeeBeanPort.Update(coffeeBean);

            // Calcular el precio total
            decimal totalPrice = coffeeBean.Price + brewingMethod.Cost;

            // Construir la orden
            var order = new Order(
                id: 0, // El repositorio asigna el id real al guardar
                customerName: customerName,
                grams: grams,
                totalPrice: totalPrice,
                coffeeBeanId: coffeeBeanId,
                brewingMethodId: brewingMethodId);

            // Guardar la orden y devolverla
            return _orderRepositoryPort.Save(order);
        }
    }
}
