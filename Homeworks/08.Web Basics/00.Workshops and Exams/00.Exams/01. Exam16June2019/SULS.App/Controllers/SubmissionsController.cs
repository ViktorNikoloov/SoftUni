using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

using SULS.App.Services;
using SULS.App.ViewModels.Submissions;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemsService problemsService,
            ISubmissionService submissionService)
        {
            this.problemsService = problemsService;
            this.submissionService = submissionService;
        }

        public HttpResponse Create(string id)
        {
            if (!IsUserSignIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = new SubmissionInputModel
            {
                ProblemId = id,
                Name = problemsService.GetNameById(id),
            };

            return View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!IsUserSignIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(code)|| 30 > code.Length || code.Length > 800)
            {
                return Error("The text should be between 30 and 800 characters long.");
            }

            var userId = GetUserId();
            submissionService.Create(problemId, userId, code);

            return Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!IsUserSignIn())
            {
                return Redirect("/Users/Login");
            }

            submissionService.Delete(id);

            return Redirect("/");
        }
    }
}
