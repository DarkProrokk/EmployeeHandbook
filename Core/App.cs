using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public class App
    {
        public App()
        {
        }

        public async Task RunAsync(IServiceProvider serviceProvider,string[] args)
        {
            Console.WriteLine("#########################################");
            var commandHandler = serviceProvider.GetRequiredService<CreateDatabaseCommand>();
        }
        public void Run()
        {
            Console.WriteLine("work");
        }
    }
}
