using System.Collections.Generic;

using SIS.HTTP;

namespace SIS.MvcFramework
{
    public interface IMvcApplication
    {
        void ConfigureServices();

        void Configure(List<Route> routeTable);
    }
}
