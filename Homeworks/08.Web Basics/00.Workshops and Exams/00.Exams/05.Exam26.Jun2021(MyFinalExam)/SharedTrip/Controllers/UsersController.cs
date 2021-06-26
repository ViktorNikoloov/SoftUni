namespace SharedTrip.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SharedTrip.Services.Users;
    using SharedTrip.ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                //return Redirect("/");

                return Error($"401 Unauthorized"); //This way is more user-friendly.
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginFormModel model)
        {
            var userId = usersService.UserLogin(model);

            if (User.IsAuthenticated)
            {
                //return Redirect("/");

                return Error($"401 Unauthorized"); //This way is more user-friendly.
            }

            if (userId == null)
            {
                //return Redirect("/Users/Login"); 

                return Error("Invalid username or password"); //This way is more user-friendly.
            }

            SignIn(userId);

            return Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                //return Redirect("/");

                return Error($"401 Unauthorized"); //This way is more user-friendly.
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterFormModel model)
        {
            var isUserNameAvaible = usersService.IsUsernameAvaible(model.Username);
            var isEmailAvaible = usersService.IsEmailAvaible(model.Email);

            if (User.IsAuthenticated)
            {
                //return Redirect("/");

                return Error($"401 Unauthorized"); //This way is more user-friendly.
            }

            if (string.IsNullOrWhiteSpace(model.Username) || 5 > model.Username.Length || model.Username.Length > 20)
            {
                //return Redirect("/Users/Register"); 
                return Error("Invalid username. The username should be between 5 and 20 characters."); //This way is more user-friendly.
            }

            if (!Regex.IsMatch(model.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                //return Redirect("/Users/Register"); 
                return Error("Invalid username. Only aphanumeric character are allowed."); //This way is more user-friendly.
            }

            if (!isUserNameAvaible)
            {
                //return Redirect("/Users/Register"); 
                return Error("Username is not avaible!"); //This way is more user-friendly.
            }

            if (string.IsNullOrWhiteSpace(model.Password) || 6 > model.Password.Length || model.Password.Length > 20)
            {
                //return Redirect("/Users/Register"); 
                return Error("Invalid password. The password should be between 6 and 20 characters."); //This way is more user-friendly.
            }

            if (model.Password != model.ConfirmPassword)
            {
                //return Redirect("/Users/Register"); 
                return Error("The passwords does not match."); //This way is more user-friendly.
            }

            if (string.IsNullOrWhiteSpace(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
            {
                //return Redirect("/Users/Register"); 
                return Error("Invalid email."); //This way is more user-friendly.
            }

            if (!isEmailAvaible)
            {
                //return Redirect("/Users/Register"); 
                return Error("Email already taken."); //This way is more user-friendly.
            }

            usersService.CreateUser(model);

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            SignOut();

            return Redirect("/");
        }
    }
}
