using SIS.HTTP;
using SIS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return View();
        }
    }
}
