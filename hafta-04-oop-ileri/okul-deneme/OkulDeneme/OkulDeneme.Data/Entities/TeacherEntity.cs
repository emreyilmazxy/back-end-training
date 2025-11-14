using OkulDeneme.Data.Entities;
using OkulDeneme.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Entities
{
    public class TeacherEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
        public UserType UserType { get; set; }

        // Navigation properties
        public ICollection<CourseEntity> Courses { get; set; } = new List<CourseEntity>();

    }// end of Teacher class
}
 public class TeacherConfiguration : BaseConfigutation<TeacherEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(t => t.LastName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(t => t.Field)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(t => t.UserType)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (UserType)Enum.Parse(typeof(UserType), v));
        base.Configure(builder);
    } // end of Configure method
}