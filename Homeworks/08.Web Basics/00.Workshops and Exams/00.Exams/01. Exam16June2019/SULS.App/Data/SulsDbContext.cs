using Microsoft.EntityFrameworkCore;
using SULS.App.Models;

namespace SULS.App.Data
{
    public class SulsDbContext : DbContext
    {
        public SulsDbContext()
        {

        }

        public SulsDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }
    }
}
