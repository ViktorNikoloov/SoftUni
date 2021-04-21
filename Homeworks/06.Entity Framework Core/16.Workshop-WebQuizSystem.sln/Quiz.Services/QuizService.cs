using Quiz.Data;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public QuizService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(string title)
        {
            var quiz = new Models.Quiz
            {
                Title = title
            };

            applicationDbContext.Quizzes.Add(quiz);
            applicationDbContext.SaveChanges();
        }
    }
}
