using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BrewingMethod
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Cost { get; init; }

        private BrewingMethod() { }

        public BrewingMethod(int id, string name, decimal cost)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException("El nombre del método de preparación es obligatorio.");
            if (cost < 0)
                throw new BusinessException("El costo no puede ser negativo.");

            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
