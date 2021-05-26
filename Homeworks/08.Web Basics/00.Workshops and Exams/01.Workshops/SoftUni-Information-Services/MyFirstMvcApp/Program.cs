using System.Threading.Tasks;
using MyFirstMvcApp.Controllers;
using SIS.HTTP;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TODO: {controller}/{action}/{id}
            IHttpServer server = new HttpServer();

            /*route table*/
            server.AddRoute("/", new HomeController().Index);
            server.AddRoute("/about", new HomeController().About);
            server.AddRoute("/users/login", new UsersController().Login);
            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);

            //If we want to auto-start the HomePage
            //Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", "http://localhost/");
            await server.StartAsync(80);
        }
    }
}
