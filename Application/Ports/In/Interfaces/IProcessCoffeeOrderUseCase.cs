using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.In.Interfaces
{
    public interface IProcessCoffeeOrderUseCase
    {
        bool CheckAvailability(int coffeeBeanId, decimal grams);
        Order ProcessOrder(string customerName, decimal grams, int coffeeBeanId, int brewingMethodId);
        Order GetOrderById(int orderId);
    }
}
