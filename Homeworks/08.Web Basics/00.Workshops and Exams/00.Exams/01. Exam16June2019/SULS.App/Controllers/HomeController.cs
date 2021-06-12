using System.Collections.Generic;

using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

using SULS.App.Services;
using SULS.App.ViewModels.Problems;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemService;

        public HomeController(IProblemsService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserSignIn())
            {
                var viewModel = problemService.GetAllProblems();
                return View(viewModel, "IndexLoggedIn");
            }

            return View();
        }
    }
}
