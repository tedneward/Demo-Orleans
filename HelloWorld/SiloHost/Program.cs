using System.Xml.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Dashboard;

// {{## BEGIN scaffolding ##}}
try
{
    var host = await StartSiloAsync(args);
    Console.WriteLine("\n\n Press Enter to terminate...\n\n");
    Console.ReadLine();

    await host.StopAsync();

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    return 1;
}
// {{## END scaffolding ##}}

// {{## BEGIN hostsetup ##}}
static async Task<IHost> StartSiloAsync(string[] args)
{
    var builder = new HostBuilder()
        .UseOrleans(c =>
        {
            c.UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "HelloWorld";
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .AddDashboard();
        });

    var host = builder.Build();

    await host.StartAsync();

    return host;
}
// {{## END hostsetup ##}}
