﻿using System.Linq;
using System.Text;
using System.Security.Cryptography;

using SIS.MvcFramework;
using MyFirstMvcApp.Data;
using MyFirstMvcApp.Data.Models;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService()
        {
            db = new ApplicationDbContext();
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Role = IdentityRole.User,
                Password = ComputeHash(password),
            };

            db.Users.Add(user);
            db.SaveChangesAsync();

            return user.Id;
        }

        public string GetUserId(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username);
            if (user?.Password != ComputeHash(password))
            {
                return null;
            }
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