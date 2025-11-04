using Application.Command;
using Application.Interfaces;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI
{
    public static class ApplicationDiRegistri
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services
            .AddServices();
        private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<ICommand, CreateDatabaseCommand>();
    }
}
