using ConsoleApp1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var processesTypes = Assembly.GetExecutingAssembly().ExportedTypes
    .Where(t => t.IsClass && t.IsAssignableTo(typeof(BaseProcess)) && !t.IsAbstract);

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    })
    .ConfigureServices((config, services) =>
    {
        var processConfigurations=config.Configuration.GetSection("application").Get<List<ProcessConfiguration>>()
            .Where(x => x.IsRunning).ToList();
        processesTypes = processesTypes.Where(pt => processConfigurations.Select(pc => pc.ClassName).Contains(pt?.Name));

        foreach (var itemType in processesTypes)
        {
            services.AddSingleton(typeof(IHostedService), itemType);
        }
    })
    .Build();

host.Run();



    

