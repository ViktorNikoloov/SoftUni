using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using SIS.HTTP;
using SIS.MvcFramework;

using SharedTrip.App.Data;
using SharedTrip.App.Services.Trips;
using SharedTrip.App.Services.Users;

namespace SharedTrip.App
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ITripsService, TripsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ShareTripDbContext().Database.Migrate();
        }
    }
}
