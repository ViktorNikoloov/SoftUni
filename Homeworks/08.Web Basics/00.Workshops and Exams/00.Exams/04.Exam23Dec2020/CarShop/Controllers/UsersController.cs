using System.Linq;

using MyWebServer.Http;
using MyWebServer.Controllers;

using CarShop.Services.Users;
using CarShop.Services.Validator;

using CarShop.ViewModels;
using CarShop.ViewModels.Users;


namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IValidator validator;

        public UsersController(IUsersService usersService,
            IValidator validator)
        {
            this.usersService = usersService;
            this.validator = validator;
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel user)
        {
            if (User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            var modelErrors = this.validator.ValidateUser(user);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            usersService.CreateUser(user);

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel user)
        {
            if (User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            var userId = usersService.IsUserExist(user);

            if (userId == null)
            {
                return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Cars/All");
        }

        public HttpResponse Logout()
        {
            if (!User.IsAuthenticated)
            {
                //return Error(string.Format(ErrorViewText, "401 Unauthorized"));
                return Error("401 Unauthorized");
            }

            this.SignOut();

            return Redirect("/");
        }
    }
}
