using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quiz.Services;

namespace Quiz.Web.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;
        private readonly IUserAnswerService userAnswerService;

        public QuizController(IQuizService quizService,
            IUserAnswerService userAnswerService)
        {
            this.quizService = quizService;
            this.userAnswerService = userAnswerService;
        }

        public IActionResult Test(int id)
        {
            quizService.StartQuiz(User?.Identity?.Name, id);
            var viewModel = quizService.GetQuizById(id);
            return View(viewModel);

        }

        public IActionResult Submit(int id)
        {
            foreach (var item in Request.Form)
            {
                var questionId = int.Parse(item.Key.Replace("q_", string.Empty));
                var answerId = int.Parse(item.Value);
                userAnswerService.AddUserAnswer(User.Identity.Name, questionId, answerId);
            }

            return RedirectToAction("Results", new {id});
            
        }
        public IActionResult Results(int id)
        {
            var points = userAnswerService.GetUserResult(User.Identity.Name, id);
            return View(points);
        }
    }
}
