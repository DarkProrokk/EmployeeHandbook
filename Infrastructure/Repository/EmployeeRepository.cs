using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class EmployeeRepository(EmployeeHandbookContext context) : IEmployeeRepository
    {
        public async Task AddEmployee(Employee employee)
        {
            Console.WriteLine("repos");
            await context.Employees.AddAsync(employee); 
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
