using Microsoft.Extensions.DependencyInjection;
using System;

using _04.WildFarm.IO;
using _04.WildFarm.IO.Contracts;

namespace _04.WildFarm
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
