using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        public int Id { get; init; }
        public string CustomerName { get; init; }
        public decimal Grams { get; init; }
        public DateTime Date { get; init; }
        public int CoffeeBeanId { get; init; }
        public int BrewingMethodId { get; init; }

        public Order(int id, string customerName, decimal grams, int coffeeBeanId, int brewingMethodId)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new BusinessException("El nombre del cliente es obligatorio.");
            if (grams <= 0)
                throw new BusinessException("La cantidad en gramos debe ser positiva.");
            if (coffeeBeanId <= 0)
                throw new BusinessException("El id del tipo de café debe ser positivo");
            if (brewingMethodId <= 0)
                throw new BusinessException("El id del método de preparación debe ser positivo");

            Id = id;
            CustomerName = customerName;
            Grams = grams;
            Date = DateTime.UtcNow;
            CoffeeBeanId = coffeeBeanId;
            BrewingMethodId = brewingMethodId;
        }
    }
}
