namespace SULS.App.ViewModels.User
{
    public class RegisterInputModel : LoginInputModel
    {
        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
