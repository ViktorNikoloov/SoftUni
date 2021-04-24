namespace Quiz.Services.Models
{
    public interface IJsonImportService
    {
        void Import(string fileName, string quizName);
    }
}
