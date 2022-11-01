namespace GrainInterfaces;

using System.Threading.Tasks;

public interface IHelloWorld : Orleans.IGrainWithIntegerKey
{
    Task<string> SayHello(string name);
}
