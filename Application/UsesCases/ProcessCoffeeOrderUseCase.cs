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

        public Order ProcessOrder(string customerName, decimal grams, int coffeeBeanId, int brewingMethodId)
        {
            // Obtener el grano y el método de preparación
            var coffeeBean = _coffeeBeanPort.GetById(coffeeBeanId);
            var brewingMethod = _brewingMethodPort.GetById(brewingMethodId);

            // Descontar los gramos pedidos en la orden
            var updatedCoffeeBean = coffeeBean.DecreaseStock(grams);
            _coffeeBeanPort.Update(updatedCoffeeBean);

            // Calcular el precio total
            decimal totalPrice = updatedCoffeeBean.Price + brewingMethod.Cost;

            // Construir la orden
            var order = new Order(
                id: 0, // El repositorio asigna el id real al guardar
                customerName: customerName,
                grams: grams,
                date: DateTime.UtcNow,
                totalPrice: totalPrice,
                coffeeBeanId: coffeeBeanId,
                brewingMethodId: brewingMethodId);

            // Guardar la orden y devolverla
            return _orderRepositoryPort.Save(order);
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepositoryPort.GetOrder(orderId);
        }
    }
}
