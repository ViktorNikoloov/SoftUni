using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using MyFirstMvcApp.Services;

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

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin(string username, string password)
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

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister(string username, string email, string password, string confirmPassword)
        {
            if (IsUserSignIn())
            {
                return Redirect("/");
            }

            if (username == null || username.Length < 5 || username.Length > 20)
            {
                return Error("Invalid username. The username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9\.]+$"))
            {
                return Error("Invalid username. Only aphanumeric character are allowed.");
            }

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return Error("Invalid email.");
            }

            if (password == null || password.Length < 6 || password.Length > 20)
            {
                return Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (password != confirmPassword)
            {
                return Error("Passwords does not match.");
            }

            if (!usersService.IsUsernameAvaible(username))
            {
                return Error("Username already taken.");
            }

            if (!usersService.IsEmailAvaible(email))
            {
                return Error("Email already taken.");
            }

            usersService.CreateUser(username, email, password);

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
