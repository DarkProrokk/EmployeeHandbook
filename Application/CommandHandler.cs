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
        public ICommand GetCommand(string commandKey, string[] args)
        {
            switch (commandKey)
            {
                case "1":
                    return serviceProvider.GetRequiredService<CreateDatabaseCommand>();
                case "2":
                    var fullName = args[1];
                    var birthDay = DateOnly.Parse(args[2]);
                    var sex = Enum.Parse<Sex>(args[3]);

                    var service = serviceProvider.GetRequiredService<IEmployeeService>();
                    return new AddRecordCommand(service, fullName, birthDay, sex);
                case "3":
                    throw new ArgumentException($"Неизвестная команда: {commandKey}");
                    break;
                case "4":
                    throw new ArgumentException($"Неизвестная команда: {commandKey}");
                    break;
                case "5":
                    throw new ArgumentException($"Неизвестная команда: {commandKey}");
                    break;
                default:
                    throw new ArgumentException($"Неизвестная команда: {commandKey}");
            }
        }
    }
}
