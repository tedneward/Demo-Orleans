namespace Grains;

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using GrainInterfaces;

public class HelloWorld : Orleans.Grain, IHelloWorld
{
    private readonly ILogger _logger;

    public HelloWorld(ILogger<HelloWorld> logger) { _logger = logger; }

    public Task<string> SayHello(string name)
    {
        _logger.LogInformation("SayHello: name = '{name}'", name);
        return Task.FromResult($"Hello, {name}, welcome to Orleans");
    }
}
