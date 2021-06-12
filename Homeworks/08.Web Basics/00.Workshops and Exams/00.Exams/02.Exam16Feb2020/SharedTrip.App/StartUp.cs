using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SharedTrip.App.Data;
using SIS.HTTP;

using SIS.MvcFramework;

namespace SharedTrip.App
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            
        }

        public void Configure(List<Route> routeTable)
        {
            new ShareTripDbContext().Database.Migrate();
        }
    }
}
