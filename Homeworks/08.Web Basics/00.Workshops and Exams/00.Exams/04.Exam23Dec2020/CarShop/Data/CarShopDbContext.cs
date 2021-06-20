using Microsoft.EntityFrameworkCore;

using CarShop.Models;

namespace CarShop.Data
{
    public class CarShopDbContext : DbContext
    {
        public CarShopDbContext()
        {

        }

        public CarShopDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Issue> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.ConfigurationString);
            }
        }
    }
}
