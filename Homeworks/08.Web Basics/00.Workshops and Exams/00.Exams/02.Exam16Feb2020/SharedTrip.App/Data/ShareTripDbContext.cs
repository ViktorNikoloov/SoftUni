using Microsoft.EntityFrameworkCore;

using SharedTrip.App.Models;

namespace SharedTrip.App.Data
{
    public class ShareTripDbContext : DbContext
    {
        public ShareTripDbContext()
        {

        }

        public ShareTripDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>().HasKey(x => new
            {
                x.UserId,
                x.TripId
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }
    }
}
