namespace SharedTrip.ViewModels.Users
{
    public class UserRegisterFormModel : UserLoginFormModel
    {
        public string Email { get; set; }

        public string ConfirmPassword { get; init; }

    }
}
