using System.Reflection;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Command
{
    public class AddRecordCommand(IEmployeeService service, string fullName, DateOnly birthDay, Sex sex) : ICommand
    {
        public async Task Execute()
        {
            //как мы сюда параметры будем передевать
            await service.CreateAsync(fullName, birthDay, sex);
        }
    }
}
