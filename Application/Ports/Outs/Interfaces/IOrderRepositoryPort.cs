using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.Outs.Interfaces
{
    public interface IOrderRepositoryPort
    {
        Order Save(Order order);
    }
}
