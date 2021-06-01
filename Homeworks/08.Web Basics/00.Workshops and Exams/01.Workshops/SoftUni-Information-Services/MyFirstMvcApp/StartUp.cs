using System.Collections.Generic;

using SIS.HTTP;
using SIS.MvcFramework;
using MyFirstMvcApp.Controllers;

namespace MyFirstMvcApp
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices()
        {
            System.Console.WriteLine("123");
        }

        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/", SIS.HTTP.Enums.HttpMethod.Get, new HomeController().Index));
            routeTable.Add(new Route("/home/about", SIS.HTTP.Enums.HttpMethod.Get, new HomeController().About));
            routeTable.Add(new Route("/users/login", SIS.HTTP.Enums.HttpMethod.Get, new UsersController().Login));
            routeTable.Add(new Route("/users/login", SIS.HTTP.Enums.HttpMethod.Post, new UsersController().DoLogin));
            routeTable.Add(new Route("/users/register", SIS.HTTP.Enums.HttpMethod.Get, new UsersController().Register));
            routeTable.Add(new Route("/cards/add", SIS.HTTP.Enums.HttpMethod.Get, new CardsController().Add));
            routeTable.Add(new Route("/cards/all", SIS.HTTP.Enums.HttpMethod.Get, new CardsController().All));
            routeTable.Add(new Route("/cards/collection", SIS.HTTP.Enums.HttpMethod.Get, new CardsController().Collection));

            /* No need anymore because of AutoRegisterStaticFiles method in Host.cs*/
            //routeTable.Add(new Route("/favicon.ico", SIS.HTTP.Enums.HttpMethod.Get, new StaticFilesController().Favicon));
            //routeTable.Add(new Route("/css/bootstrap.min.css", SIS.HTTP.Enums.HttpMethod.Get, new StaticFilesController().BootstrapCss));
            //routeTable.Add(new Route("/css/custom.css", SIS.HTTP.Enums.HttpMethod.Get, new StaticFilesController().CustomCss));
            //routeTable.Add(new Route("/js/custom.js", SIS.HTTP.Enums.HttpMethod.Get, new StaticFilesController().CustomJs));
            //routeTable.Add(new Route("/js/bootstrap.bundle.min.js", SIS.HTTP.Enums.HttpMethod.Get, new StaticFilesController().BootstrapJs));
        }
    }
}