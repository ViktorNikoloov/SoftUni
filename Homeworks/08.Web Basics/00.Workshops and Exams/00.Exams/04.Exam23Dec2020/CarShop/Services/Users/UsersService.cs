using System.Linq;

using CarShop.Data;
using CarShop.Models;
using CarShop.Services.PasswordHasher;

using CarShop.ViewModels;
using CarShop.ViewModels.Users;

using static CarShop.Data.DataConstants;

namespace CarShop.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly CarShopDbContext db;
        
        private readonly IPasswordHasher passwordHasher;

        public UsersService(
            CarShopDbContext db,
            
            IPasswordHasher passwordHasher)
        {
            this.db = db;
            
            this.passwordHasher = passwordHasher;
        }

        public void CreateUser(RegisterUserFormModel model)
        {

            var user = new User
            {
                Username = model.Username,
                Password = passwordHasher.HashPassword(model.Password),
                Email = model.Email,
                IsMechanic = model.UserType == UserTypeMechanic
            };

            db.Users.Add(user);

            db.SaveChanges();
        }

        public string IsUserExist(LoginUserFormModel model)
        {
            var hashedPassword = passwordHasher.HashPassword(model.Password);

            var userId = db
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }
    }
}
