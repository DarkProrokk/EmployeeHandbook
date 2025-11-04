using Application.Interfaces;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public class CommandHandler(IServiceProvider serviceProvider)
    {
        public ICommand GetCommand(string commandKey) => commandKey switch
        {
            "1" => serviceProvider.GetRequiredService<CreateDatabaseCommand>()
        };
    }
}
