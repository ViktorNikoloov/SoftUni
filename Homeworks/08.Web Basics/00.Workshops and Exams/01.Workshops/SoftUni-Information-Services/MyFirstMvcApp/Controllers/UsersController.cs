using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return View();
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse DoLogin()
        {
            //TODO: read data
            //TODO: check user
            //TODO: log user

            return Redirect("/");
        }
    }
}
