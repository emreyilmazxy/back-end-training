using BankApp.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities
{
    public class UserActivity : BaseEntity
    {
        public int UserId { get; set; }          
        public UserActionType Action { get; set; }    // (Login, Logout, PasswordChange, ProfileUpdate, etc.)   
        public string IpAddress { get; set; }    
        public string? Device { get; set; }      
        public DateTime Timestamp { get; set; } 

        //Navigation Property
        public UserEntity User { get; set; }
    }// end of class UserLog

    public class UserActivityConfiguration : BaseConfiguration<UserActivity>
    {
        public override void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.Property(x => x.Action)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasConversion<string>();

            builder.Property(x => x.IpAddress)
                     .IsRequired()
                     .HasMaxLength(45); // IPv6 max length

            builder.Property(x => x.Device)
                        .IsRequired(false)
                        .HasMaxLength(500);

            builder.Property(x => x.Timestamp)
                        .IsRequired();
            
            base.Configure(builder);
        }
    }
}
