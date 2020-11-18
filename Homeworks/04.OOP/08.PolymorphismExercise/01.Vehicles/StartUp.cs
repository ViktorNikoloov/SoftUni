using System;
using Microsoft.Extensions.DependencyInjection;

using Vehicles.IO;
using Vehicles.IO.Contracts;



namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IServiceProvider service = new ServiceCollection()
                .AddScoped<IReader, Reader>()
                .AddScoped<IWriter, Writer>()
                .AddScoped<Engine, Engine>()
                .BuildServiceProvider();

            Engine engine = service.GetService<Engine>();
            engine.Run();
        }
    }
}
