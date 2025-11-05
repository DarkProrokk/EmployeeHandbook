using Application.Command;
using Application.Interfaces;
using Application.Service;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application
{
    public class CommandHandler(IServiceProvider serviceProvider)
    {
        public ICommand GetCommand(string commandKey)
        {
            switch (commandKey)
            {
                case "1":
                    return serviceProvider.GetRequiredService<CreateDatabaseCommand>();
                case "2":
                    return serviceProvider.GetRequiredService<AddRecordCommand>(); ;
                case "3":
                    return serviceProvider.GetRequiredService<OutputAllRecords>();
                case "4":
                    return serviceProvider.GetRequiredService<FillEmployeeTable>();
                case "5":
                    return serviceProvider.GetRequiredService<SelectFromTableByCriterion>();
                default:
                    throw new ArgumentException($"Неизвестная команда: {commandKey}");
            }
        }
    }
}
