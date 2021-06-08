using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

using SIS.HTTP;
using SIS.HTTP.Enums;

using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

namespace SIS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int post = 80)
        {
            List<Route> routeTable = new List<Route>();
            IServiceCollection serviceCollection = new ServiceCollection();

            AutoRegisterStaticFiles(routeTable);

            application.ConfigureServices(serviceCollection);
            application.Configure(routeTable);

            AutoRegisterRoutes(routeTable, application, serviceCollection);

            Console.WriteLine("All registered routes:");
            foreach (var route in routeTable)
            {
                Console.WriteLine($"{route.Method} => {route.Path}");
            }

            IHttpServer server = new HttpServer(routeTable);

            //If we want to auto-start the HomePage or any other page
            //Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", "http://localhost/");
            await server.StartAsync(80);
        }

        private static void AutoRegisterRoutes(List<Route> routeTable, IMvcApplication application, IServiceCollection serviceCollection)
        {
            var controllerTypes = application.GetType().Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Controller)));
            foreach (var controllerType in controllerTypes)
            {
                var methods = controllerType.GetMethods()
                    .Where(x =>
                    x.IsPublic &&
                    x.DeclaringType == controllerType &&
                    !x.IsStatic &&
                    !x.IsAbstract &&
                    !x.IsConstructor &&
                    !x.IsSpecialName);

                foreach (var method in methods)
                {
                    var url = "/" + controllerType.Name.Replace("Controller", string.Empty) + "/" + method.Name;

                    var attribute = method.GetCustomAttributes(false)
                        .Where(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute)))
                        .FirstOrDefault() as BaseHttpAttribute;

                    var httpMethod = HttpMethod.Get;

                    if (attribute != null)
                    {
                        httpMethod = attribute.Method;
                    }

                    if (!string.IsNullOrEmpty(attribute?.Url))
                    {
                        url = attribute.Url;
                    }

                    routeTable.Add(new Route(url, httpMethod, (request) =>
                    {
                        /*There's no need to give parameters to action methods*/
                        var instance = serviceCollection.CreateInstance(controllerType) as Controller;
                        instance.Request = request;
                        var response = method.Invoke(instance, new object[] { }) as HttpResponse;

                        return response;
                    }));
                }
            }
        }

        private static void AutoRegisterStaticFiles(List<Route> routeTable)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);
            foreach (var staticFile in staticFiles)
            {
                var url = staticFile.Replace("wwwroot", string.Empty).Replace("\\", "/");

                routeTable.Add(new Route(url, HttpMethod.Get, (request) =>
                {
                    var filecontenct = File.ReadAllBytes(staticFile);
                    var fileExt = new FileInfo(staticFile).Extension;
                    var content = fileExt switch
                    {
                        ".txt" => "text/plain",
                        ".js" => "text/javascript",
                        ".css" => "text/css",
                        ".jpg" => "image/jpg",
                        ".jpeg" => "image/jpg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        ".ico" => "image/vnd.microsoft.icon",
                        ".html" => "text/html",
                        _ => "text/plain",
                    };

                    return new HttpResponse(content, filecontenct, HttpStatusCode.OK);
                }));
            }
        }
    }
}
