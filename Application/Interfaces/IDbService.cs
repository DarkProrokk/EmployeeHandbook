using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDbService
    {
        public Task CreateDbAsync();
/*        public Task CreateRecord(Employee employee);
        public Task OutputAllRecords();*/
    }
}
