using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class BrewingMethodEntity
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public BrewingMethodEntity() { }

        public BrewingMethodEntity(int id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}