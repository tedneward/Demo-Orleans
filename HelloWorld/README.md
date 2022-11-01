# HelloWorld
There are four projects in the solution, all of which are necessary to build and run an Orleans solution:

### GrainInterfaces
This project contains nothing but interfaces that act as the shared contract (the IDL, if you will) between clients and servers. As a result, this project is needed on both client and server side of the system; that is to say, if you want to be a client to the grains offered by this Orleans system, you need to reference and import the interfaces from here.

Created with `dotnet new classlib -n GrainInterfaces`.

Dependencies added: 
* `dotnet add package Microsoft.Orleans.Core.Abstractions`
* `dotnet add package Microsoft.Orleans.OrleansCodeGenerator.Build`

### Grains
This project contains the implementations of the grains offered by this Orleans system. As a result, it is used (only) by the SiloHost. (We could combine this project and the SiloHost project, but it's generally likely that you may want to host grains from a variety of different hosts--such as an ASP.NET host, for example--so it's not a bad idea to keep these projects apart in general unless you know for absolute certain that it will never be hosted anywhere else. Which, I daresay, you probably don't.)

Created with `dotnet new classlib -n Grains`.

Dependencies added: 
* `dotnet add package Microsoft.Orleans.Core.Abstractions`
* `dotnet add package Microsoft.Orleans.OrleansCodeGenerator.Build`
* `dotnet add reference ../GrainInterfaces`

### Client
Created with `dotnet new console -n Client`.

Dependencies added:
* `dotnet add package Microsoft.Orleans.Client`
* `dotnet add package Microsoft.Extensions.Logging.Console`
* `dotnet add reference ../GrainInterfaces`

### SiloHost
Created with `dotnet new console -n SiloHost`.

Dependencies added:
* `dotnet add package Microsoft.Orleans.Server`
* `dotnet add package Microsoft.Extensions.Logging.Console`
* `dotnet add package Microsoft.Extensions.Hosting`
* `dotnet add reference ../GrainInterfaces`
* `dotnet add reference ../Grains`


To build, ....

To run, ....

