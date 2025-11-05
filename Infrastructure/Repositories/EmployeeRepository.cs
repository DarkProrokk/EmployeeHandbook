using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EmployeeRepository(EmployeeHandbookContext context) : IEmployeeRepository
    {
        public async Task AddEmployee(Employee employee)
        {
            await context.Employees.AddAsync(employee); 
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await context.Employees
                        .OrderBy(e => e.FullName)
                        .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public async Task<List<Employee>> GetEmployeeMaleWithLastNameStartingWithFAsync()
        {
           return await context.Employees
                        .Where(e => e.Sex == Sex.Male && e.FullName.StartsWith("F"))
                        .ToListAsync();
        }
    }
}
