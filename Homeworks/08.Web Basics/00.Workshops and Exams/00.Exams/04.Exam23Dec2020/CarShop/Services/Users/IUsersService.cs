using CarShop.ViewModels;
using CarShop.ViewModels.Users;

namespace CarShop.Services.Users
{
    public interface IUsersService
    {
        void CreateUser(RegisterUserFormModel user);

        string IsUserExist(LoginUserFormModel user);
    }
}
