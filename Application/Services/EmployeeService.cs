using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
    {
        public async Task CreateAsync(string fullname, DateOnly birthDay, Sex sex)
        {

            var employee = Employee.CreateEmployee(fullname, birthDay, sex);
            await repository.AddEmployee(employee);
            await repository.SaveAsync();
        }

        public async Task<IEnumerable<EmployeeDTO>> OutputAllRecordsAsync()
        {
            var employees = await repository.GetAllAsync();
            return employees.Select(e => new EmployeeDTO
            {
                FullName = e.FullName,
                BirthDay = e.BirthDay,
                Sex = e.Sex,
                Age = e.CalculateAge()
            }).ToList();
        }

        public async Task<IEnumerable<EmployeeDTO>> OutputRecordsByFilterAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            var employees = await repository.GetEmployeeMaleWithLastNameStartingWithFAsync();
            stopwatch.Stop();
            Console.WriteLine($"Запрос занял: {stopwatch.Elapsed.TotalMilliseconds} мс");
            return employees.Select(e => new EmployeeDTO
            {
                FullName = e.FullName,
                BirthDay = e.BirthDay,
                Sex = e.Sex,
                Age = e.CalculateAge()
            });
        }
    }
}
