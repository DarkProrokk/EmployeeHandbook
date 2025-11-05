using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Infrastructure.Service;
using Infrastructure.Repository;
using Application.Services;
namespace Infrastructure.DI
{
    public static class InfrastructureDiRegistri
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services
            .AddDatabase(configuration)
            .AddServices();
        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<EmployeeHandbookContext>(
                options => options.UseSqlServer(connectionString));

            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services) => 
            services
            .AddScoped<IDbService, DbService>()
            .AddScoped<IEmployeeRepository,EmployeeRepository>();
    }
}
