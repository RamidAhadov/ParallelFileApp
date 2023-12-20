using System.Diagnostics;
using Autofac;
using Microsoft.Extensions.Configuration;
using ParallelFileApp.Configuration;
using ParallelFileApp.FileCreation;
using ParallelFileApp.FileCreation.Abstraction;

var container = ConfigureContainer();
var path = container.Resolve<Configs>();
var creator = container.Resolve<FileCreator>();

IContainer ConfigureContainer()
{
    var builder = new ContainerBuilder();

    builder.Register(c => new ConfigurationBuilder()
            .SetBasePath("/Users/macbook/RiderProjects/ParallelFileApp/ParallelFileApp.Configuration")
            .AddJsonFile("appsettings.json")
            .Build())
        .As<IConfiguration>()
        .SingleInstance();

    builder.RegisterType<Configs>().As<IConfigs>();
    builder.RegisterType<Configs>();
        
    builder.RegisterType<FileCreator>().As<ICreator>();
    builder.RegisterType<FileCreator>();

    return builder.Build();

}

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
creator.CreateFile(path.Path());
stopwatch.Stop();

Console.WriteLine("Elapsed time: {0}",stopwatch.ElapsedMilliseconds);
Console.WriteLine("Press any button to continue");
Console.ReadLine();

// stopwatch.Start();
// creator.DeleteFile(path.Path());
// stopwatch.Stop();
//
// Console.WriteLine("Elapsed time: {0}",stopwatch.ElapsedMilliseconds);


