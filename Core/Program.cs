/*foreach (var arg in args)
{
    Console.WriteLine(arg);
}*/
using Application.DI;
using Core;
using Infrastructure.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("Core/appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string? connectionString = configuration.GetConnectionString("Database");

var services = new ServiceCollection();

services.AddInfrastructure(configuration);
services.AddApplication();
services.AddSingleton<App>();

var provider = services.BuildServiceProvider();

var app = provider.GetRequiredService<App>();

await app.RunAsync(provider,args);