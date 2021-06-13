using SIS.HTTP;

using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

namespace SharedTrip.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserSignIn())
            {
                Redirect("/Trips/All");
            }

            return View();
        }
    }
}
