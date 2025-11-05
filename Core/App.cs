using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Service;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public class App
    {
        public App()
        {
        }

        public async Task RunAsync(IServiceProvider serviceProvider, string[] args)
        {
            Console.WriteLine("#########################################");
            Console.WriteLine(args[0]);

            var commandHandler = new CommandHandler(serviceProvider);
            var command = commandHandler.GetCommand(args[0], args);

            await command.Execute();
        }
    }
}
