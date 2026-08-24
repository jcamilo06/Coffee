using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.Outs.Interfaces
{
    public interface IBrewingMethodPort
    {
        BrewingMethod GetById(int brewingMethodId);
        List<BrewingMethod> GetAll();
    }
}
