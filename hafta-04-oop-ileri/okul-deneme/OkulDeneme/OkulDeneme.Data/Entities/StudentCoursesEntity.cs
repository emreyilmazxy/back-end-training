using OkulDeneme.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Entities
{
    public class StudentCoursesEntity : BaseEntity
    {
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }

        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }// end of class StudentCourses
}

public class StudentCoursesConfiguration : BaseConfigutation<StudentCoursesEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentCoursesEntity> builder)
    {
        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });
        builder.HasOne(sc => sc.Student)
            .WithMany(s => s.courses)
            .HasForeignKey(sc => sc.StudentId);
        builder.HasOne(sc => sc.Course)
            .WithMany(c => c.Students)
            .HasForeignKey(sc => sc.CourseId);
        base.Configure(builder);
    } // end of Configure method
} // end of class StudentCoursesConfiguration
