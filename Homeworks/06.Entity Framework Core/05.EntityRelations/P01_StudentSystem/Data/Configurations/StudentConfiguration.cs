using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student.HasKey(s => s.StudentId);

            student
                .Property(s => s.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            student
                .Property(s => s.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(10);
        }
    }
}
