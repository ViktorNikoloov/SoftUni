using MyWebServer.Http;
using MyWebServer.Controllers;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return View();
        }
    }
}
