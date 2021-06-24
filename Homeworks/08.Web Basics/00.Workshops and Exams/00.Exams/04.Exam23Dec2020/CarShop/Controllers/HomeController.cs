using MyWebServer.Http;
using MyWebServer.Controllers;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Cars/All");
            }

            return View();
        }
    }
}
