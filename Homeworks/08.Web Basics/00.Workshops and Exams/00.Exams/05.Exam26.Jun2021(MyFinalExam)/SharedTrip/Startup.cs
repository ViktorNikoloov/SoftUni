namespace SharedTrip
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using Controllers;
    using SharedTrip.Data;
    using SharedTrip.Services.Users;
    using SharedTrip.Services.Trips;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUsersService, UsersService>()
                    .Add<ITripsService, TripsService>()
                    .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
