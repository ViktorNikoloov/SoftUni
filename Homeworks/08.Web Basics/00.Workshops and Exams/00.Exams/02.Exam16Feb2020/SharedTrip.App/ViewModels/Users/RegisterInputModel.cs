namespace SharedTrip.App.ViewModels.Users
{
    public class RegisterInputModel : LoginInputModel
    {
        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
