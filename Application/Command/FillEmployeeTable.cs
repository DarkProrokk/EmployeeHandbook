using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class FillEmployeeTable(IRecordGeneratorService service) : ICommand
    {
        public async Task Execute(string[] args)
        {
            await service.GenerateBulk(1000000);
            await service.GenerateSpecialFEmployees();
        }
    }
}
