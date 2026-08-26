using API.Middleware;
using Application.Ports.In;
using Application.Ports.Outs;
using Application.UsesCases;
using Infrastructure.Adapters.Outs.Persistence;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Registro de dependencias de la arquitectura hexagonal
            builder.Services.AddSingleton<ICoffeeBeanPort, InMemoryCoffeeBeanAdapter>();
            builder.Services.AddSingleton<IBrewingMethodPort, InMemoryBrewingMethodAdapter>();
            builder.Services.AddSingleton<IOrderRepositoryPort, InMemoryOrderAdapter>();
            builder.Services.AddScoped<IProcessCoffeeOrderUseCase, ProcessCoffeeOrderUseCase>();
            builder.Services.AddScoped<ICoffeeBeanQueryUseCase, CoffeeBeanQueryUseCase>();
            builder.Services.AddScoped<IBrewingMethodQueryUseCase, BrewingMethodQueryUseCase>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
