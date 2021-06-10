namespace SULS.App.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUsernameAvaible(string username);

        bool IsEmailAvaible(string email);
    }
}
