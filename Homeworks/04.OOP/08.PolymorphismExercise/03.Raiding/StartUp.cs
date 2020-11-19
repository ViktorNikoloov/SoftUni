using Microsoft.Extensions.DependencyInjection;
using System;

using _03.Raiding.Core;
using _03.Raiding.IO;
using _03.Raiding.IO.Contracts;

namespace _03.Raiding
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
