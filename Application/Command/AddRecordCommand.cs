using System.Reflection;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Command
{
    public class AddRecordCommand(IEmployeeService service) : ICommand
    {
        public async Task Execute()
        {
            //как мы сюда параметры будем передевать
            await service.CreateAsync("Ivanov Petr Sergeevich" ,new DateOnly(2009,12,01), Sex.Male);
        }
    }
}
