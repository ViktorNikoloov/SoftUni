using SIS.HTTP;
using SIS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return View("Views/Users/Login.cshtml");
        }

        public HttpResponse Register(HttpRequest request)
        {
            return View("Views/Users/Register.cshtml");
        }
    }
}
