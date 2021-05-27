﻿using System.Collections.Generic;
using System.Threading.Tasks;

using SIS.HTTP;

namespace SIS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(List<Route> routeTable, int post = 80)
        {
            IHttpServer server = new HttpServer(routeTable);
  
            //If we want to auto-start the HomePage
            //Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", "http://localhost/");
            await server.StartAsync(80);
        }
    }
}
