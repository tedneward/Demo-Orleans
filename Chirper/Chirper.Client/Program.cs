using Chirper.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

Console.Title = "Chirper Client";

await new HostBuilder()
    .UseOrleansClient(builder =>
        builder.UseStaticClustering(new IPEndPoint[]
        {
            IPEndPoint.Parse("172.22.37.222:30000")
        }))
    .ConfigureServices(
        services => services
            .AddSingleton<IHostedService, ShellHostedService>()
            .Configure<ConsoleLifetimeOptions>(sp => sp.SuppressStatusMessages = true))
    .ConfigureLogging(builder => builder.AddDebug())
    .RunConsoleAsync();
