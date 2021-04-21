namespace Quiz.Services
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string userId, int quizId, int questionId, int answerId);
    }
}
