namespace SharedTrip.Services.Users
{
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(UserRegisterFormModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = ComputeHash(model.Password),
            };

            db.Users.Add(user);
            db.SaveChangesAsync();
        }

        public string UserLogin(UserLoginFormModel model)
        {
            var passwordHash = ComputeHash(model.Password);
            var user = db.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == passwordHash);

            return user?.Id;
        }

        public bool IsEmailAvaible(string email)
        => !db.Users.Any(x => x.Email == email);


        public bool IsUsernameAvaible(string username)
        => !db.Users.Any(x => x.Username == username);


        public static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));

            return hashedInputStringBuilder.ToString();
        }

    }
}
