using SIS.HTTP;
using SIS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return View("Views/Home/Index.cshtml");
        }

    }
}
