using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


using SIS.HTTP;
using SIS.HTTP.Enums;

namespace SIS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int post = 80)
        {
            List<Route> routeTable = new List<Route>();

            AutoRegisterStaticFiles(routeTable );
            application.ConfigureServices();
            application.Configure(routeTable);

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
