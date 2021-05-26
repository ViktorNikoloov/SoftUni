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
            server.AddRoute("/users/login", new UsersController().Login);
            server.AddRoute("/users/register", new UsersController().Register);
            server.AddRoute("/cards/add", new CardsController().Add);
            server.AddRoute("/cards/all", new CardsController().All);
            server.AddRoute("/cards/collection", new CardsController().Collection);
            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);

            //If we want to auto-start the HomePage
            //Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", "http://localhost/");
            await server.StartAsync(80);
        }
    }
}
