using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NMLabs.ConsoleApp;
using NMLabs.Core.Interfaces;
using NMLabs.Core.Services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<IPlotSevice, PlotService>();
        services.AddSingleton<MenuService>();
        services.AddTransient<ILabSolver, NMLabs.Labs.Lab1_Advection.LabSolver>();
    })
    .Build();

var menuService = host.Services.GetRequiredService<MenuService>();
await menuService.ShowMenuAsync();

await host.RunAsync();