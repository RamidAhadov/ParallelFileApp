using System.Diagnostics;
using Autofac;
using Microsoft.Extensions.Configuration;
using ParallelFileApp.Configuration;
using ParallelFileApp.FileWriting;
using ParallelFileApp.FileWriting.Abstraction;


var container = ConfigureContainer();
var config = container.Resolve<Configs>();
var writer = container.Resolve<FileWriter>();

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
writer.Write(config.Path(),config.Text());
stopwatch.Stop();

Console.WriteLine("Elapsed time: {0}",stopwatch.ElapsedMilliseconds);




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
        
    builder.RegisterType<FileWriter>().As<IWriter>();
    builder.RegisterType<FileWriter>();

    return builder.Build();

}