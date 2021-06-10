using System.Linq;
using System.Security.Cryptography;
using System.Text;

using SULS.App.Data;
using SULS.App.Models;

namespace SULS.App.Services
{
    public class UsersService : IUsersService
    {
        private readonly SulsDbContext db;

        public UsersService(SulsDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };

            db.Users.Add(user);
            db.SaveChangesAsync();

            return user.Id;
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == passwordHash);
          
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
