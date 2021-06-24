namespace CarShop.Services.PasswordHasher
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
