using Microsoft.EntityFrameworkCore;

namespace _04.EfCodeFirstDemo.Models
{
    public class SliDoDbContext : DbContext
    {
        public SliDoDbContext()
        {

        }

        public SliDoDbContext(DbContext dbContext)
            :base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SliDo;Integrated Security=true;");
            }
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}
