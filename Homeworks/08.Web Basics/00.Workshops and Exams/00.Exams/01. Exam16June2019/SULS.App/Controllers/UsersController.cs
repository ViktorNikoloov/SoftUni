using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

using SULS.App.Services;
using SULS.App.ViewModels.User;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (IsUserSignIn())
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            var username = model.Username;
            var password = model.Password;
            var userId = usersService.GetUserId(username, password);

            if (IsUserSignIn())
            {
                return Redirect("/");
            }

            if (userId == null)
            {
                return Error("Invalid username or password");
            }

            SignIn(userId);

            return Redirect("/");
        }

        public HttpResponse Register()
        {
            if (IsUserSignIn())
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            var username = model.Username;
            var еmail = model.Email;
            var password = model.Password;
            var isUserNameAvaible = usersService.IsUsernameAvaible(username);
            var isEmailAvaible = usersService.IsEmailAvaible(еmail);

            if (IsUserSignIn())
            {
                return Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(username) || 5 > username.Length || username.Length > 20)
            {
                return Error("Invalid username. The username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(model.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return Error("Invalid username. Only aphanumeric character are allowed.");
            }

            if (!isUserNameAvaible)
            {
                return Error("Username is not avaible!");
            }

            if (string.IsNullOrWhiteSpace(password) || 6 > password.Length || password.Length > 20)
            {
                return Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Error("The passwords does not match.");
            }

            if (string.IsNullOrWhiteSpace(еmail) || !new EmailAddressAttribute().IsValid(еmail))
            {
                return Error("Invalid email.");
            }

            if (!isEmailAvaible)
            {
                return Error("Email already taken.");
            }

            usersService.CreateUser(username, еmail, password);

            return Redirect("/Users/Login");
        }

        

        public HttpResponse Logout()
        {
            if (!IsUserSignIn())
            {
                return Error("Only logged-in users can logout.");
            }

            SignOut();

            return Redirect("/");
        }
    }
}
