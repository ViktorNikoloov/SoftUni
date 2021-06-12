using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

using SULS.App.Services;
using SULS.App.ViewModels.Problems;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemService;

        public ProblemsController(IProblemsService problemService)
        {
            this.problemService = problemService;
        }

        public HttpResponse Create()
        {
            if (!IsUserSignIn())
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel model)
        {
            var name = model.Name.ToLower();
            var points = model.Points;
            bool isProblemExist = problemService.IsProblemExist(name);

            if (!IsUserSignIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(name) || 5 > name.Length || name.Length > 20 || isProblemExist)
            {
                return Error("The name should be between 5 and 20 charachters long.");
            }

            if (50 > points || points > 300)
            {
                return Error("The points should be a number between 50 and 300 .");
            }

            problemService.AddProblem(name, points);

            return Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!IsUserSignIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = problemService.GetById(id);

            return View(viewModel);
        }
    }
}
