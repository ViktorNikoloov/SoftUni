using Microsoft.EntityFrameworkCore;

using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var dbContext = new SalesContext();
            dbContext.Database.Migrate();
        }
    }
}
