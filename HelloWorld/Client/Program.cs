using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;

using GrainInterfaces;

try
{
    var client = await ConnectClientAsync();
    await DoClientWorkAsync(client);
    Console.ReadKey();

    return 0;
}
catch (Exception e)
{
    Console.WriteLine($"\nException while trying to run client: {e.Message}");
    Console.WriteLine("Make sure the silo the client is trying to connect to is running.");
    Console.WriteLine("\nPress any key to exit.");
    Console.ReadKey();
    return 1;
}

static async Task<IClusterClient> ConnectClientAsync()
{
    var host = new HostBuilder()
        .UseOrleansClient(c => {
            c.UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "HelloWorld";
            });
        })
        .ConfigureLogging(logging => logging.AddConsole())
        .Build();
    await host.StartAsync();

    Console.WriteLine("Client successfully connected to silo host \n");

    return host.Services.GetRequiredService<IClusterClient>();
}

static async Task DoClientWorkAsync(IClusterClient client)
{
    var friend = client.GetGrain<IHelloWorld>(0);
    var response = await friend.SayHello("Good morning, HelloGrain!");

    Console.WriteLine($"\n\n{response}\n\n");
}