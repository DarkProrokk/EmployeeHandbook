using System.Reflection;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Command
{
    public class AddRecordCommand(IEmployeeService service) : ICommand
    {
        public async Task Execute(string[] args)
        {
            var fullName = args[1];
            var birthDay = DateOnly.Parse(args[2]);
            var sex = Enum.Parse<Sex>(args[3]);

            await service.CreateAsync(fullName, birthDay, sex);
        }
    }
}
