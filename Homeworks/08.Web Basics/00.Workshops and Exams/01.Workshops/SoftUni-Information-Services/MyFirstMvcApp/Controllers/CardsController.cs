using SIS.HTTP;
using SIS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add(HttpRequest request)
        {
            return View("Views/Cards/Add.cshtml");
        }

        public HttpResponse All(HttpRequest request)
        {
            return View("Views/Cards/All.cshtml");
        }

        public HttpResponse Collection(HttpRequest request)
        {
            return View("Views/Cards/Collection.cshtml");
        }
    }
}
