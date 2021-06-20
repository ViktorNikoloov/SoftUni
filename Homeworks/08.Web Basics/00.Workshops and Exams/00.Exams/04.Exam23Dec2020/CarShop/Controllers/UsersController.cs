using MyWebServer.Http;
using MyWebServer.Controllers;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Register()
        {
            return View();
        }

        public HttpResponse Login()
        {
            return View();
        }
    }
}
