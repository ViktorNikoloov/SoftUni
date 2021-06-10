using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using SIS.HTTP;
using SIS.MvcFramework;
using SULS.App.Data;
using SULS.App.Services;

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
            serviceCollection.Add<ISubmissionService, SubmissionService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}
