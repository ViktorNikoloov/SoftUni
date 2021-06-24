using System.Collections.Generic;

using CarShop.ViewModels;

namespace CarShop.Services.Validator
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel user);
    }
}
