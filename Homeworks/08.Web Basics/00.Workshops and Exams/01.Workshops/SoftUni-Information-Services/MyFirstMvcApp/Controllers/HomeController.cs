using System;

using SIS.HTTP;
using SIS.MvcFramework;

using MyFirstMvcApp.ViewModels;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";

            return View(viewModel);
        }

        public HttpResponse About(HttpRequest request)
        {
            return View();
        }
    }
}
