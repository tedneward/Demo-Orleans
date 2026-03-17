using Microsoft.Extensions.Hosting;
using Orleans.Configuration;
using System.Net;

Console.Title = "Chirper Server";

await Host.CreateDefaultBuilder(args)
    .UseOrleans(
        builder => builder
        .Configure<EndpointOptions>(options =>
        {
            // Port to use for silo-to-silo
            options.SiloPort = 11_111;
            // Port to use for the gateway
            options.GatewayPort = 30_000;
            // IP Address to advertise in the cluster
            options.AdvertisedIPAddress = IPAddress.Parse("192.168.0.114");
            // The socket used for client-to-silo will bind to this endpoint
            options.GatewayListeningEndpoint = new IPEndPoint(IPAddress.Any, 40_000);
            // The socket used by the gateway will bind to this endpoint
            options.SiloListeningEndpoint = new IPEndPoint(IPAddress.Any, 50_000);
        })
        .AddMemoryGrainStorage("AccountState"))
    .RunConsoleAsync();
