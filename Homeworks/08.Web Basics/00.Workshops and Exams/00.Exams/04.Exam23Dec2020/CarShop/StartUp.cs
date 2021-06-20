using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MyWebServer;
using MyWebServer.Controllers;

using CarShop.Data;

namespace CarShop
{
    public class StartUp
    {
        public static async Task Main()
        => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithConfiguration<CarShopDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
