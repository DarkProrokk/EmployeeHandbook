using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRecordGeneratorService
    {
        public Task GenerateBulk(int count);
        public Task GenerateSpecialFEmployees(int count = 100);

    }
}
