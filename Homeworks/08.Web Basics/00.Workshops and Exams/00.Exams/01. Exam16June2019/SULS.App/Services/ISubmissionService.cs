namespace SULS.App.Services
{
    public interface ISubmissionService
    {
        void Create(string problemId, string UserId, string code);
    }
}
