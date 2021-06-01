using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

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

        [HttpPost]
        public HttpResponse DoLogin(HttpRequest request)
        {
            //TODO: read data
            //TODO: check user
            //TODO: log user

            return Redirect("/");
        }
    }
}
