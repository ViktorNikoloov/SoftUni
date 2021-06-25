using System.Collections.Generic;

using CarShop.ViewModels;
using CarShop.ViewModels.Cars;

namespace CarShop.Services.Validator
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel user);
        ICollection<string> ValidateCar(AddCarFormViewModel car);
    }
}
