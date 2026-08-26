using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class CoffeeBeanEntity
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal GramsStock { get; set; }

        public CoffeeBeanEntity() { }

        public CoffeeBeanEntity(int id, string name, decimal price, decimal gramsStock)
        {
            Id = id;
            Name = name;
            Price = price;
            GramsStock = gramsStock;
        }
    }
}
