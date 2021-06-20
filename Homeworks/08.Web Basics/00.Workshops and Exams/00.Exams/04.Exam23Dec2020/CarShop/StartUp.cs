﻿using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MyWebServer;
using MyWebServer.Controllers;

using CarShop.Data;
using MyWebServer.Results.Views;
using System.ComponentModel.DataAnnotations;

namespace CarShop
{
    public class StartUp
    {
        public static async Task Main()
        => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<CarShopDbContext>())
                .WithConfiguration<CarShopDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
