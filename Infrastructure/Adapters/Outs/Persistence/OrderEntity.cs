using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Outs.Persistence
{
    public class OrderEntity
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Grams { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int CoffeeBeanId { get; set; }
        public int BrewingMethodId { get; set; }

        public OrderEntity() { }

        public OrderEntity(int id, string customerName, decimal grams, DateTime date, decimal totalPrice, int coffeeBeanId, int brewingMethodId)
        {
            Id = id;
            CustomerName = customerName;
            Grams = grams;
            Date = date;
            TotalPrice = totalPrice;
            CoffeeBeanId = coffeeBeanId;
            BrewingMethodId = brewingMethodId;
        }
    }
}
