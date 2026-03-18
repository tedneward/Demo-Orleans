using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System.Net;

Console.Title = "Chirper Server";

await Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering(
            siloPort: 11111,
            gatewayPort: 30000,
            primarySiloEndpoint: new IPEndPoint(IPAddress.Loopback, 11111));

        silo.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "game";
        });

        silo.Configure<SiloOptions>(opts =>
        {
            opts.SiloName = "silo-0";
        });
    })
    .RunConsoleAsync();

