using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task CreateAsync(string fullname, DateOnly birthday, Sex sex);
        public Task<IEnumerable<EmployeeDTO>> OutputAllRecordsAsync();
        public Task<IEnumerable<EmployeeDTO>> OutputRecordsByFilterAsync();
    }
}
