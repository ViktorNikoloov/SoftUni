using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course.HasKey(c => c.CourseId);

            course
                .Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(80);

            course
                .Property(x => x.Description)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(255);
                
        }
    }
}
