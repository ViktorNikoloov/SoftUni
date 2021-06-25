using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using CarShop.Data;
using CarShop.ViewModels;
using CarShop.ViewModels.Cars;

using static CarShop.Data.DataConstants;

namespace CarShop.Services.Validator
{
    public class Validator : IValidator
    {
        private readonly CarShopDbContext db;

        public Validator(CarShopDbContext db)
        {
            this.db = db;
        }

        public ICollection<string> ValidateCar(AddCarFormViewModel car)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(car.Model) || car.Model.Length < CarModelMinLength || car.Model.Length > DefaultMaxLength)
            {
                errors.Add($"Model '{car.Model}' is not valid. It must be between {CarModelMinLength} and {DefaultMaxLength} characters long.");
            }

            if (car.Year == null)
            {
                errors.Add($"Car's year can not be empty");
            }

            Uri uriResult;
            bool result = Uri.TryCreate(car.Image, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;
            if (result)
            {
                errors.Add($"Invalid url address \"{car.Image}\"");
            }

            if (!Regex.IsMatch(car.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                errors.Add($"Invalid plate number \"{car.PlateNumber}\"");
            }


            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UserMinUsername || user.Username.Length > DefaultMaxLength)
            {
                //errors.Add(string.Format(ErrorViewText, $"Username '{user.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long."));

                errors.Add($"Username '{user.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < UserMinPassword || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            if (user.UserType != UserTypeClient && user.UserType != UserTypeMechanic)
            {
                errors.Add($"The user can be either a '{UserTypeClient}' or a '{UserTypeMechanic}'.");
            }

            if (this.db.Users.Any(u => u.Username == user.Username))
            {
                errors.Add($"User with '{user.Username}' username already exists.");
            }

            if (this.db.Users.Any(u => u.Email == user.Email))
            {
                errors.Add($"User with '{user.Email}' e-mail already exists.");
            }

            return errors;
        }
    }
}
