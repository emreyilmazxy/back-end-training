using OkulDeneme.Data.Entities;
using OkulDeneme.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Entities
{
    public class StudentEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }

        public int Note { get; set; }
        public int Absence { get; set; }

        // Navigation properties
        public ICollection<StudentCoursesEntity> courses { get; set; } = new List<StudentCoursesEntity>();
    }// end of Student class
}
  public class StudentConfiguration : BaseConfigutation<StudentEntity>
{
     public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentEntity> builder)
     {
         builder.Property(s => s.Name)
             .IsRequired()
             .HasMaxLength(50);
         builder.Property(s => s.LastName)
             .IsRequired()
             .HasMaxLength(50);
         builder.Property(s => s.UserType)
             .IsRequired()
             .HasConversion(
                 v => v.ToString(),
                 v => (UserType)Enum.Parse(typeof(UserType), v));
         base.Configure(builder);
    } // end of Configure method
}