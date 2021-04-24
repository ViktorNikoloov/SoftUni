using Quiz.Services.Models;

namespace Quiz.Services
{
    public interface IQuizService
    {
        int Add(string title);

        QuizViewModel GetQuizById(int quizId);
    }
}
