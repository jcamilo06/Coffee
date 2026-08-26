using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.Outs
{
    public interface IOrderRepositoryPort
    {
        Order Save(Order order);
        Order GetOrder(int orderId);
    }
}
