using _04.EfCodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace _04.EfCodeFirstDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
           // db.Database.EnsureCreated();

           db.Database.Migrate();
        }
    }
}
