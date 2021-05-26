using System.Text;

using SIS.HTTP;
using SIS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>! Login !</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse Register(HttpRequest request)
        {
            var responseHtml = "<h1>! Register !</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
