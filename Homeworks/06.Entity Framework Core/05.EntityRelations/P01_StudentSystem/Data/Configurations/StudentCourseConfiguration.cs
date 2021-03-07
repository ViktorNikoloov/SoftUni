using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> studentCourse)
        {
            studentCourse.HasKey(sc => new
            {
                sc.StudentId,
                sc.CourseId
            });

            studentCourse
                .HasOne(s => s.Student)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            studentCourse
                .HasOne(c => c.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
