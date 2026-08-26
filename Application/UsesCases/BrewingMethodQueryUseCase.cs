using Application.Ports.In.Interfaces;
using Application.Ports.Outs.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases
{
    public class BrewingMethodQueryUseCase : IBrewingMethodQueryUseCase
    {
        private readonly IBrewingMethodPort _brewingMethodPort;

        public BrewingMethodQueryUseCase(IBrewingMethodPort brewingMethodPort)
        {
            _brewingMethodPort = brewingMethodPort;
        }

        public List<BrewingMethod> GetAllBrewingMethods() => _brewingMethodPort.GetAll();
    }
}
