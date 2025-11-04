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
            var command = commandHandler.GetCommand(args[0]);

            if (args.Length != 4)
            {
                Console.WriteLine("myApp 2 \"FullName\" YYYY-MM-DD Male/Female");
                return;
            }

            var fullName = args[1];
            var birthDay = DateOnly.Parse(args[2]);
            var sex = Enum.Parse<Sex>(args[3]);

            await command.Execute();
        }
    }
}
