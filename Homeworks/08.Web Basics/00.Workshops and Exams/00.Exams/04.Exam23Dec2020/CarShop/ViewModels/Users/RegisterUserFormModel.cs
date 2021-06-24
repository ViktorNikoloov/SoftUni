using CarShop.ViewModels.Users;

namespace CarShop.ViewModels
{
    public class RegisterUserFormModel : LoginUserFormModel
    {
        public string Email { get; set; }

        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
    }
}
