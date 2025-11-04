using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
namespace Application.Service
{
    public class CreateDatabaseCommand(IDbService service) : ICommand
    {

        public async Task Execute()
        {
            await service.CreateDbAsync();
        }
    }
}
