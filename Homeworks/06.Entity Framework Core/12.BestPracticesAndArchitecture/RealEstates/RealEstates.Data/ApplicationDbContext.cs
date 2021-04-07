using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

namespace RealEstates.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConfigurationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyTag>()
                .HasKey(pt => new
                {
                    pt.PropertyId,
                    pt.TagId
                });
        }
    }
}
