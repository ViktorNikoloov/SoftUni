namespace Quiz.Services
{
    public interface IAnswerService
    {
        int Add(string title, int points, bool isCorrenct, int questionId);
    }
}
