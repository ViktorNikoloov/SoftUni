namespace SharedTrip.Services.Users
{
    using SharedTrip.ViewModels.Users;

    public interface IUsersService
    {
        void CreateUser(UserRegisterFormModel model);

        string UserLogin(UserLoginFormModel model);

        bool IsUsernameAvaible(string username);

        bool IsEmailAvaible(string email);
    }
}
