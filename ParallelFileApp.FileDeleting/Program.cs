using System.Diagnostics;
using Autofac;
using Microsoft.Extensions.Configuration;
using ParallelFileApp.Configuration;
using ParallelFileApp.FileDeleting;
using ParallelFileApp.FileDeleting.Abstraction;

var container = ConfigureContainer();
var config = container.Resolve<Configs>();
var deleter = container.Resolve<FileDeleter>();

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
// deleter.Delete(config.Path());
deleter.ManualThreadedDelete(config.Path());
stopwatch.Stop();

Console.WriteLine("Elapsed time: {0}",stopwatch.ElapsedMilliseconds);

// for (int i = 1; i <= (i+1); i++)
// {
//     Console.WriteLine(i);
// }

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
        
    builder.RegisterType<FileDeleter>().As<IDeleter>();
    builder.RegisterType<FileDeleter>();

    return builder.Build();

}