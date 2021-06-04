using System;

using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

using MyFirstMvcApp.ViewModels;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";

            if (Request.Session.ContainsKey("about"))
            {
                viewModel.Message += "YOU ARE ON THE ABOUT PAGE";
            }

            return View(viewModel);
        }

        public HttpResponse About()
        {
            Request.Session["about"] = "yes";
            return View();
        }
    }
}
