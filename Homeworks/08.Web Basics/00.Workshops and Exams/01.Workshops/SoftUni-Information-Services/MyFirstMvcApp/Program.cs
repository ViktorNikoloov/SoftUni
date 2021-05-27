﻿using System.Collections.Generic;
using System.Threading.Tasks;

using SIS.MvcFramework;
using SIS.HTTP;

using MyFirstMvcApp.Controllers;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*route table*/
            List<Route> routeTable = new List<Route>();
            routeTable.Add(new Route("/", new HomeController().Index));
            routeTable.Add(new Route("/users/login", new UsersController().Login));
            routeTable.Add(new Route("/users/register", new UsersController().Register));
            routeTable.Add(new Route("/cards/add", new CardsController().Add));
            routeTable.Add(new Route("/cards/all", new CardsController().All));
            routeTable.Add(new Route("/cards/collection", new CardsController().Collection));

            routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFilesController().BootstrapCss));
            routeTable.Add(new Route("/css/custom.css", new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/js/custom.js", new StaticFilesController().CustomJs));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFilesController().BootstrapJs));

            await Host.CreateHostAsync(routeTable);
        }
    }
}
