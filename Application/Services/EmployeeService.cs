using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
    {
        public async Task CreateAsync(string fullname, DateOnly birthday, Sex sex)
        {
            var employee = Employee.CreateEmployee(fullname, birthday, sex);

            await repository.AddEmployee(employee);
            await repository.SaveAsync();
        }
    }
}
