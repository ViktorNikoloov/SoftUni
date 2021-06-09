using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using MyFirstMvcApp.Services;
using MyFirstMvcApp.ViewModels.Users;

using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

namespace MyFirstMvcApp.Controllers
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
        public HttpResponse Login(string username, string password)
        {
            var userId = usersService.GetUserId(username, password);

            if (userId == null)
            {
                return Error("Invalid username or password");
            }

            SignIn(userId);

            return Redirect("/Cards/All");
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
        public HttpResponse Register(DoRegisterViewModel model)
        {
            if (IsUserSignIn())
            {
                return Redirect("/");
            }

            if (model.Username == null || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return Error("Invalid username. The username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(model.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return Error("Invalid username. Only aphanumeric character are allowed.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
            {
                return Error("Invalid email.");
            }

            if (model.Password == null || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Error("Passwords does not match.");
            }

            if (!usersService.IsUsernameAvaible(model.Username))
            {
                return Error("Username already taken.");
            }

            if (!usersService.IsEmailAvaible(model.Email))
            {
                return Error("Email already taken.");
            }

            usersService.CreateUser(model.Username, model.Email, model.Password);

            return Redirect("/Users/Login");
        }

        public HttpResponse LogOut()
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
