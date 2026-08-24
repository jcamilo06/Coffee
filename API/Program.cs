using API.Middleware;
using Application.Ports.In.Interfaces;
using Application.Ports.In.UsesCases;
using Application.Ports.Outs.Interfaces;
using Infrastructure.Adapters.Outs.Implementations;

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
