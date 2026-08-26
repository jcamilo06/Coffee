// Infrastructure/Config/InfrastructureConfig.cs
using Application.Ports.In;
using Application.Ports.Outs;
using Application.UsesCases;
using Infrastructure.Adapters.Outs.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Config
{
    public static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories (Singleton, mantienen el estado en memoria)
            services.AddSingleton<InMemoryCoffeeBeanRepository>();
            services.AddSingleton<InMemoryBrewingMethodRepository>();
            services.AddSingleton<InMemoryOrderRepository>();

            // Adapters (implementan los puertos de salida)
            services.AddSingleton<ICoffeeBeanPort, InMemoryCoffeeBeanAdapter>();
            services.AddSingleton<IBrewingMethodPort, InMemoryBrewingMethodAdapter>();
            services.AddSingleton<IOrderRepositoryPort, InMemoryOrderAdapter>();

            // Use Cases (Scoped, sin estado propio)
            services.AddScoped<IProcessCoffeeOrderUseCase, ProcessCoffeeOrderUseCase>();
            services.AddScoped<ICoffeeBeanQueryUseCase, CoffeeBeanQueryUseCase>();
            services.AddScoped<IBrewingMethodQueryUseCase, BrewingMethodQueryUseCase>();

            return services;
        }
    }
}