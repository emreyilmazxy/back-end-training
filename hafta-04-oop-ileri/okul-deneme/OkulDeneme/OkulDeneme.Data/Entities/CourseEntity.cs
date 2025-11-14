using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OkulDeneme.Data.Entities;
using OkulDeneme.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Entities
{
    public class CourseEntity : BaseEntity
    {
        public string Title { get; set; }
        public UserType UserType { get; set; }

        public int TeacherId { get; set; }

        // Navigation properties
        public TeacherEntity Teacher { get; set; }

        public ICollection<StudentCoursesEntity> Students { get; set; } = new List<StudentCoursesEntity>();

    } // end of Course class
}

public class  CourseConfiguration : BaseConfigutation<CourseEntity>
{
    public override void Configure(EntityTypeBuilder<CourseEntity> builder)
     {

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.TeacherId)
            .IsRequired();
       
        builder.Property(c => c.UserType)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (UserType)Enum.Parse(typeof(UserType), v));

        base.Configure(builder);

    }
} // end of CourseConfiguration class
