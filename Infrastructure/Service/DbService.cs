using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Service
{
    public class DbService(EmployeeHandbookContext context) : IDbService
    {
        public async Task CreateDbAsync()
        {
            await context.Database.EnsureCreatedAsync();
        }

/*        public async Task CreateRecord(Employee employee)
        {
            await context.AddRangeAsync(employee);
        }*/
    }
}
