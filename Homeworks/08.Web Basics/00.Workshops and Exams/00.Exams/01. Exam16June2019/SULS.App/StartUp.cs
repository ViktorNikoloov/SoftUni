using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using SIS.HTTP;
using SIS.MvcFramework;
using SULS.App.Data;

namespace SULS.App
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new SulsDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}
