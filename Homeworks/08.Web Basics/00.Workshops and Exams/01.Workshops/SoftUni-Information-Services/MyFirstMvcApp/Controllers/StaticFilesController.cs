using SIS.HTTP;
using SIS.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        /* No need anymore because of AutoRegisterStaticFiles method in Host.cs*/

        //public HttpResponse Favicon(HttpRequest request)
        //{
        //    return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        //}

        //internal HttpResponse BootstrapCss(HttpRequest request)
        //{
        //    return this.File("wwwroot/css/bootstrap.min.css", "text/css");

        //}

        //internal HttpResponse CustomCss(HttpRequest request)
        //{
        //    return this.File("wwwroot/css/custom.css", "text/css");

        //}

        //internal HttpResponse BootstrapJs(HttpRequest request)
        //{
        //    return this.File("wwwroot/bootstrap.bundle.min.jc", "text/javascript");
        //}

        //internal HttpResponse CustomJs(HttpRequest request)
        //{
        //    return this.File("wwwroot/js/custom.js", "text/javascript");

        //}
    }
}
