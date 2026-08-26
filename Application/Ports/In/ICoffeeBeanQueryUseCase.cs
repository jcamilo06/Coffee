using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.In
{
    public interface ICoffeeBeanQueryUseCase
    {
        List<CoffeeBean> GetAllCoffeeBeans();
        bool CheckAvailability(int coffeeBeanId, decimal grams);
    }
}
