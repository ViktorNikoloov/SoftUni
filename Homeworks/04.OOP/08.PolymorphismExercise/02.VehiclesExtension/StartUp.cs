using Microsoft.Extensions.DependencyInjection;
using System;
using Vehicles.IO;
using Vehicles.IO.Contracts;

namespace Vehicles
{
    class StartUp
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
