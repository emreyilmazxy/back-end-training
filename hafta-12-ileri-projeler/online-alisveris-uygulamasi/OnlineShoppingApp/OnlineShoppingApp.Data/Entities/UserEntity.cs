using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShoppingApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public UserType UserType { get; set; }
        
        // Navigation properties
        public ICollection<OrderEntity> Orders { get; set; }

    } //userclass done

    public class  UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            builder.Property(x=> x.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                    .IsRequired(false)
                    .HasMaxLength(15);

            builder.Property(x => x.Password)
                    .IsRequired()
                    .HasMaxLength(500);

            builder.Property(x => x.UserType)
                    .IsRequired()
                    .HasConversion(
                        v => v.ToString(),
                        v => (UserType)Enum.Parse(typeof(UserType), v));

            builder.HasIndex(x => x.Email)
                    .IsUnique();

            builder.Property(x => x.BirthDate)
       .IsRequired()
       .HasColumnType("date");

            base.Configure(builder);
        }
    } // UserConfiguration class done
}
