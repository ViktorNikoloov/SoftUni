using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;
using SULS.App.ViewModels;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterViewModel model)
        {

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return View();
        }
    }
}
