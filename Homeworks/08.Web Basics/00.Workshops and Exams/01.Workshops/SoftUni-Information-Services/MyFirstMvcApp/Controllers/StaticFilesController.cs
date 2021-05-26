using System.IO;

using SIS.HTTP;
using SIS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return response;
        }
    }
}
