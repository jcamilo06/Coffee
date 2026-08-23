using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CoffeeBean
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public decimal GramsStock { get; private set; }

        public CoffeeBean(int id, string name, decimal price, decimal gramsStock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException("El nombre del grano es obligatorio.");
            if (price <= 0)
                throw new BusinessException("El precio debe ser positivo.");
            if (gramsStock < 0)
                throw new BusinessException("El stock no puede ser negativo.");

            Id = id;
            Name = name;
            Price = price;
            GramsStock = gramsStock;
        }

        public bool HasEnoughStock(decimal grams) => GramsStock >= grams;

        public void DecreaseStock(decimal grams)
        {
            if (!HasEnoughStock(grams))
                throw new BusinessException($"Inventario insuficiente de {Name}.");

            GramsStock -= grams;
        }
    }
}
