namespace Infrastructure.Adapters.In
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public decimal Grams { get; set; }
        public int CoffeeBeanId { get; set; }
        public int BrewingMethodId { get; set; }
    }
}
