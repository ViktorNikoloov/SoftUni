namespace SharedTrip.App.Services.Users
{
    public class IUsersService
    {
        string CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUsernameAvaible(string username);

        bool IsEmailAvaible(string email);
    }
}
